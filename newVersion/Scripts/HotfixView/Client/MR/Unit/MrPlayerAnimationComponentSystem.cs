using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace ET.Client
{
    [EntitySystemOf(typeof (PlayerAnimationComponent))]
    [FriendOf(typeof (PlayerAnimationComponent))]
    [FriendOf(typeof (PlayerAnimationResourceComponent))]
    [FriendOf(typeof (PlayerWeaponResourceComponent))]
    [FriendOf(typeof (MrArmWeaponComponent))]
    public static partial class MrPlayerAnimationComponentSystem
    {
        [EntitySystem]
        private static void Awake(this PlayerAnimationComponent self)
        {
            var unit = self.GetParent<Unit>();
            self.UnitRef = unit;

            var go = unit.GetComponent<MrGameObjectComponent>().GameObject;

            self.Posture = "Girl";
            self.AnimationSpeed = self.IdleOrMoveAnimationSpeed = 2f;
            self.Face = 0f;
            self.SetWeaponMode(unit.GetComponent<MrArmWeaponComponent>().Mode);
            self.Animator = new AuAnimator2(go.name, go.GetComponent<Animator>(), self.IdleClip, self.RunGroup.clips,
                self.RunGroup.moveDistance, () => self.AnimationSpeed, () => self.Face);
            self.SetMatirals();

            self.EquipWeapon();

            self.FXToCreate = new List<FX>();
            self.FXToRemove = new List<FX>();

            self.FXDirectors = new Dictionary<FX, PlayableDirector>();

            self.AudioToCreate = new Queue<Audio>();
            self.ImpulseToCreate = new Queue<Impulse>();
        }

        [EntitySystem]
        private static void Destroy(this PlayerAnimationComponent self)
        {
            self.Animator?.Dispose();
            self.Animator = null;

            self.UnitRef = null;
        }

        public static void ChangeWeapon(this PlayerAnimationComponent self, ArmWeaponMode armWeaponMode)
        {
            self.SetWeaponMode(armWeaponMode);
            self.EquipWeapon();
        }

        private static void UnequipWeapons(this PlayerAnimationComponent self)
        {
            foreach (GameObject weaponObject in self.WeaponObjects)
            {
                UnityEngine.Object.Destroy(weaponObject);
            }

            self.WeaponObjects.Clear();
        }

        private static void EquipWeapon(this PlayerAnimationComponent self)
        {
            self.UnequipWeapons();

            WeaponConfig config = WeaponConfigCategory.Instance.Get((int)self.ArmWeaponMode);
            for (int i = 0; i < config.Prefabs.Length; ++i)
            {
                string prefabKey = config.Prefabs[i];
                GameObject weapenPrefab = self.Root().GetComponent<PlayerWeaponResourceComponent>().GetWeaponPrefab(prefabKey);
                if (weapenPrefab == null)
                {
                    Log.Error($"error prefab key: {prefabKey}, weaponType={self.ArmWeaponMode}, index={i}");
                    continue;
                }

                Transform weapenParent = self.GetParent<Unit>().GetComponent<MrGameObjectComponent>().GameObject.transform.Find($"Weapons/{i + 1}");
                var pc = weapenParent.GetComponent<ParentConstraint>();
                pc.weight = 0;
                GameObject weaponGo = UnityEngine.Object.Instantiate(weapenPrefab, weapenParent, false);
                self.WeaponObjects.Add(weaponGo);
                for (int j = 0; j < pc.sourceCount; j++)
                {
                    ConstraintSource source = pc.GetSource(j);
                    source.weight = config.EquipPosition[i] == j? 1 : 0;
                    pc.SetSource(j, source);
                }

                pc.weight = 1;
            }
        }

        [EntitySystem]
        private static void Update(this PlayerAnimationComponent self)
        {
            self.UpdateSkill();
            self.UpdateIdleOrMove();
            self.UpdateAnimator();
            self.UpdateFX();
            self.UpdateAudio();
            self.UpdateImpulse();
            self.UpdatePosition();
            self.UpdateRim();
            self.UpdateSplash();
        }

        private static void UpdateSkill(this PlayerAnimationComponent self)
        {
            if (self.IsCastingSkill)
            {
                if (self.CastingSkill != null)
                {
                    self.SkillTime += Time.deltaTime;
                }
                else
                {
                    // 之前的技能已经失效了(结束或打断)
                    self.ClearFXs();
                    self.AudioToCreate.Clear();
                    self.ImpulseToCreate.Clear();
                    self.IsCastingSkill = false;
                    self.SkillTime = 0;
                }
            }

            if (self.IsCastingSkill)
            {
                return;
            }

            var castingSkill = self.Unit.GetComponent<ClientSkillComponent>().CastingSkill;
            self.IsCastingSkill = castingSkill != null;
            self.CastingSkillRef = castingSkill;

            if (castingSkill == null)
            {
                // 没有正在释放的技能
                return;
            }

            var oldState = self.PlayerAnimatorState;
            var blendMove = oldState switch
            {
                PlayerAnimatorState.Idle => false,
                PlayerAnimatorState.Run => false,
                PlayerAnimatorState.Skill => true,
                _ => false
            };
            self.PlayerAnimatorState = PlayerAnimatorState.Skill;

            var skillName = castingSkill.GetSkillName();
            var dataClip = self.CurrentClip = self.getDataClip(skillName);
            if (dataClip == null)
            {
                Log.Error($"没有找到AnimationClip: {skillName}");
                return;
            }

            self.AnimationSpeed = 1f;
            self.SkillTime = 0;
            //
            foreach (CharacterAnimationDataClip.EffectConfig effectConfig in dataClip.effectConfigs)
            {
                var fx = CreateFXFromConfig(effectConfig);
                self.FXToCreate.Add(fx);
            }

            //
            foreach (CharacterAnimationDataClip.AudioConfig audioConfig in dataClip.audioConfigs)
            {
                var audio = new Audio { Time = audioConfig.startPoint.AsFloat(), Clip = audioConfig.audioClip };
                self.AudioToCreate.Enqueue(audio);
            }

            //
            foreach (CharacterAnimationDataClip.ImpulseConfig impulseConfig in dataClip.impulseConfigs)
            {
                var impulse = new Impulse() { Time = impulseConfig.startPoint, power = impulseConfig.power };
                self.ImpulseToCreate.Enqueue(impulse);
            }

            if (dataClip.clip != null)
            {
                self.Animator.PlayAnim(dataClip.clip, blendMove);
            }
            else
            {
                self.Animator.PlayAnim(dataClip.customAnims, blendMove);
            }
        }

        private static void UpdateIdleOrMove(this PlayerAnimationComponent self)
        {
            if (self.IsCastingSkill)
            {
                return;
            }

            self.AnimationSpeed = self.IdleOrMoveAnimationSpeed;
            var moveComponent = self.Unit.GetComponent<MoveComponent>();
            if (moveComponent == null)
            {
                return;
            }

            if (moveComponent.StartTime == 0)
            {
                if (self.PlayerAnimatorState == PlayerAnimatorState.Idle)
                {
                    return;
                }

                self.PlayerAnimatorState = PlayerAnimatorState.Idle;
                self.Animator.PlayIdle();
            }
            else
            {
                if (self.PlayerAnimatorState == PlayerAnimatorState.Run)
                {
                    return;
                }

                self.PlayerAnimatorState = PlayerAnimatorState.Run;
                self.Animator.SetMove(self.RunGroup.clips, self.RunGroup.moveDistance);
                self.Animator.PlayMove();
            }
        }

        private static void UpdateAnimator(this PlayerAnimationComponent self)
        {
            float step = Time.deltaTime * self.AnimationSpeed;
            self.Animator.Evaluate(step);
        }

        private static void UpdateFX(this PlayerAnimationComponent self)
        {
            Transform playerTransform = null;
            for (int i = 0; i < self.FXToCreate.Count; ++i)
            {
                var fx = self.FXToCreate[i];
                if (self.SkillTime < fx.start || self.SkillTime >= fx.end)
                {
                    continue;
                }

                playerTransform ??= self.GetParent<Unit>().GetComponent<MrGameObjectComponent>().GameObject.transform;
                GameObject fxGo = UnityEngine.Object.Instantiate(fx.target, playerTransform);
                var tr = fxGo.transform;
                tr.localPosition = fx.position;
                tr.localEulerAngles = fx.rotation;
                tr.localScale = fx.scale;
                if (!fx.follow)
                {
                    tr.SetParent(null, true);
                }

                var director = fxGo.GetComponent<PlayableDirector>();
                director.timeUpdateMode = DirectorUpdateMode.Manual;
                self.FXDirectors.Add(fx, director);

                self.FXToRemove.Add(fx);
                self.FXToCreate.RemoveAt(i--);
            }

            for (int i = 0; i < self.FXToRemove.Count; i++)
            {
                var fx = self.FXToRemove[i];

                if (self.SkillTime < fx.end)
                {
                    continue;
                }

                UnityEngine.Object.Destroy(self.FXDirectors[fx].gameObject);
                self.FXDirectors.Remove(fx);
                self.FXToRemove.RemoveAt(i--);
            }

            float step = Time.deltaTime * self.AnimationSpeed;
            foreach ((FX fx, PlayableDirector director) in self.FXDirectors)
            {
                director.time += step * fx.speed;
                director.Evaluate();
            }
        }

        private static void ClearFXs(this PlayerAnimationComponent self)
        {
            self.FXToCreate.Clear();
            self.FXToRemove.Clear();

            foreach (var fx in self.FXDirectors)
            {
                UnityEngine.Object.Destroy(fx.Value.gameObject);
            }

            self.FXDirectors.Clear();
        }

        private static FX CreateFXFromConfig(CharacterAnimationDataClip.EffectConfig conf)
        {
            var effect = new FX();
            effect.start = conf.startPoint;
            effect.end = conf.endPoint;
            effect.target = conf.target;
            effect.follow = conf.follow;
            effect.speed = conf.speed;
            effect.position = conf.position;
            effect.rotation = conf.rotation;
            effect.scale = conf.scale;
            return effect;
        }

        private static void UpdateAudio(this PlayerAnimationComponent self)
        {
            while (self.AudioToCreate.TryPeek(out var audio))
            {
                if (audio.Time > self.SkillTime)
                {
                    return;
                }

                var unitAudio = self.GetParent<Unit>().GetComponent<UnitAudio>();
                unitAudio.PlayOneShot(audio.Clip);

                self.AudioToCreate.Dequeue();
            }
        }

        private static void UpdateImpulse(this PlayerAnimationComponent self)
        {
            while (self.ImpulseToCreate.TryPeek(out var audio))
            {
                if (audio.Time > self.SkillTime)
                {
                    return;
                }

                self.Impulse(audio.power);

                self.ImpulseToCreate.Dequeue();
            }
        }

        private static void Impulse(this PlayerAnimationComponent self, Vector3 power)
        {
            var gameObject = self.GetParent<Unit>().GetComponent<MrGameObjectComponent>().GameObject;
            var s = gameObject.AddComponent<CinemachineImpulseSource>();
            s.m_ImpulseDefinition.m_ImpulseType = CinemachineImpulseDefinition.ImpulseTypes.Uniform;
            s.m_ImpulseDefinition.m_ImpulseShape = CinemachineImpulseDefinition.ImpulseShapes.Bump;
            s.m_DefaultVelocity = power;
            s.GenerateImpulseWithForce(1);
            UnityEngine.Object.Destroy(s, 2);
        }

        private static void UpdatePosition(this PlayerAnimationComponent self)
        {
            var go = self.GetParent<Unit>().GetComponent<MrGameObjectComponent>().GameObject;
            go.transform.position = self.GetParent<Unit>().Position;
            // Log.Info($"pos: {self.GetParent<Unit>().Position}");
        }

        private static CharacterAnimationDataClip getDataClip(this PlayerAnimationComponent self, string name)
        {
            return self.Root().GetComponent<PlayerAnimationResourceComponent>().Get(name);
        }

        private static void SetWeaponMode(this PlayerAnimationComponent self, ArmWeaponMode armWeaponMode)
        {
            self.ArmWeaponMode = armWeaponMode;
            self.IdleClip = self.GetAnimationDataClip("Idle").clip;
            self.RunGroup = self.GetRunGroup();

            // 创建Animator之前会调用
            if (self.Animator != null)
            {
                self.Animator.SetIdle(self.IdleClip);
                self.Animator.SetMove(self.RunGroup.clips, self.RunGroup.moveDistance);

                if (self.ArmWeaponMode == ArmWeaponMode.Unarmed)
                {
                    if (self.PlayerAnimatorState == PlayerAnimatorState.Idle)
                    {
                        self.Animator.PlayIdle();
                    }

                    self.Animator.CloseBlend();
                }
            }
        }

        private static CharacterAnimationDataClip GetAnimationDataClip(this PlayerAnimationComponent self, string name)
        {
            var resCom = self.Root().GetComponent<PlayerAnimationResourceComponent>();
            return resCom.Get(self.Posture, self.ArmWeaponMode, name);
        }

        private static PlayerAnimatorRunData GetRunGroup(this PlayerAnimationComponent self, ArmWeaponMode armWeaponMode)
        {
            var group = new PlayerAnimatorRunData(8);
            group[0] = self.GetAnimationDataClip($"Run{armWeaponMode}_F");
            group[1] = self.GetAnimationDataClip($"Run{armWeaponMode}_FL");
            group[2] = self.GetAnimationDataClip($"Run{armWeaponMode}_L");
            group[3] = self.GetAnimationDataClip($"Run{armWeaponMode}_BL");
            group[4] = self.GetAnimationDataClip($"Run{armWeaponMode}_B");
            group[5] = self.GetAnimationDataClip($"Run{armWeaponMode}_BR");
            group[6] = self.GetAnimationDataClip($"Run{armWeaponMode}_R");
            group[7] = self.GetAnimationDataClip($"Run{armWeaponMode}_FR");
            return group;
        }

        private static PlayerAnimatorRunData GetRunGroup(this PlayerAnimationComponent self)
        {
            PlayerAnimatorRunData group = new(8);
            group[0] = self.GetAnimationDataClip("Run_F");
            group[1] = self.GetAnimationDataClip("Run_FL");
            group[2] = self.GetAnimationDataClip("Run_L");
            group[3] = self.GetAnimationDataClip("Run_BL");
            group[4] = self.GetAnimationDataClip("Run_B");
            group[5] = self.GetAnimationDataClip("Run_BR");
            group[6] = self.GetAnimationDataClip("Run_R");
            group[7] = self.GetAnimationDataClip("Run_FR");
            return group;
        }

        private static PlayerAnimatorRunData GetDashGroup(this PlayerAnimationComponent self)
        {
            PlayerAnimatorRunData group = new(8);
            group[0] = self.GetAnimationDataClip("Sprint");
            group[1] = self.GetAnimationDataClip("Run_FL");
            group[2] = self.GetAnimationDataClip("Run_L");
            group[3] = self.GetAnimationDataClip("Run_BL");
            group[4] = self.GetAnimationDataClip("Run_B");
            group[5] = self.GetAnimationDataClip("Run_BR");
            group[6] = self.GetAnimationDataClip("Run_R");
            group[7] = self.GetAnimationDataClip("Run_FR");
            return group;
        }

        private static void SetMatirals(this PlayerAnimationComponent self)
        {
            GameObject go = self.GetParent<Unit>().GetComponent<MrGameObjectComponent>().GameObject;

            foreach (Transform node in go.GetComponentsInChildren<Transform>())
            {
                var renderer = node.GetComponent<Renderer>();
                if (!renderer)
                    continue;
                self.Materials.AddRange(renderer.materials);
            }

            self.ResetRim();
            self.ResetSplash();
        }

        private static void ResetRim(this PlayerAnimationComponent self)
        {
            foreach (var mat in self.Materials)
            {
                mat.SetInt("_UseRim", 0);
                mat.SetColor("_RimColor", new Color(1, 1, 1, 1));
                mat.SetTexture("_RimColorTex", null);

                mat.SetFloat("_RimMainStrength", 0);
                mat.SetFloat("_RimEnableLighting", 0);
                mat.SetFloat("_RimShadowMask", 0);
                mat.SetInt("_RimBackfaceMask", 0);
                mat.SetFloat("_RimBlendMode", 1);

                mat.SetFloat("_RimDirStrength", 0);
                mat.SetFloat("_RimIndirBorder", 1);
                mat.SetFloat("_RimBlur", 1);
                mat.SetFloat("_RimFresnelPower", 2);
                mat.SetFloat("_RimVRParallaxStrength", 0);
            }
        }

        private static void UpdateRim(this PlayerAnimationComponent self)
        {
            if (self.DefRimColorLerp <= 0)
            {
                return;
            }

            self.DefRimColorLerp -= Time.deltaTime * 10;

            Color o = self.DefRimCurColor;
            Color n = Color.Lerp(self.DefRimTarColor, self.DefRimLasColor, self.DefRimColorLerp);

            switch (o.a)
            {
                case 0 when n.a > 0:
                {
                    foreach (Material mat in self.Materials)
                    {
                        mat.SetInt("_UseRim", 1);
                    }

                    break;
                }
                case > 0 when n.a == 0:
                {
                    foreach (Material mat in self.Materials)
                    {
                        mat.SetInt("_UseRim", 0);
                    }

                    break;
                }
            }

            foreach (Material mat in self.Materials)
            {
                mat.SetColor("_RimColor", n);
            }

            self.DefRimCurColor = n;
        }

        private static void ResetSplash(this PlayerAnimationComponent self)
        {
            foreach (Material mat in self.Materials)
            {
                mat.SetInt("_UseEmission2nd", 0);
                mat.SetTexture("_Emission2ndMap", null);
                mat.SetColor("_Emission2ndColor", new Color(1, 1, 1, 1));
            }
        }

        private static void UpdateSplash(this PlayerAnimationComponent self)
        {
            if (self.SplashLerp <= 0)
            {
                return;
            }

            self.SplashLerp -= Time.deltaTime * 10;
            float o = self.SplashValue;
            float n = Mathf.Lerp(0, .3f, self.SplashLerp);

            switch (o)
            {
                case 0 when n > 0:
                {
                    foreach (Material mat in self.Materials)
                    {
                        mat.SetInt("_UseEmission2nd", 1);
                    }

                    break;
                }
                case > 0 when n == 0:
                {
                    foreach (Material mat in self.Materials)
                    {
                        mat.SetInt("_UseEmission2nd", 0);
                    }

                    break;
                }
            }

            foreach (Material mat in self.Materials)
            {
                mat.SetColor("_Emission2ndColor", new Color(1, 1, 1, n));
            }

            self.SplashValue = n;
        }
    }
}