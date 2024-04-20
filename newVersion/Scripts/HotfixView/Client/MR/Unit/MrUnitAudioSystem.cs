using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (UnitAudio))]
    [FriendOf(typeof (UnitAudio))]
    public static partial class MrUnitAudioSystem
    {
        [EntitySystem]
        private static void Awake(this UnitAudio self)
        {
            var transform = self.GetParent<Unit>().GetComponent<MrGameObjectComponent>().GameObject.transform;

            var go = new GameObject("AudioSources");
            go.transform.SetParent(transform, false);
            var count = 8;
            self.AudioSources = new AudioSource[count];
            for (int i = 0; i < count; i++)
            {
                var audioSource = go.AddComponent<AudioSource>();
                audioSource.playOnAwake = false;
                audioSource.loop = false;
                audioSource.volume = 1f;
                self.AudioSources[i] = audioSource;
            }
        }

        [EntitySystem]
        private static void Destroy(this UnitAudio self)
        {
            foreach (AudioSource audioSource in self.AudioSources)
            {
                UnityEngine.Object.Destroy(audioSource);
            }

            self.AudioSources = null;
        }

        public static void PlayOneShot(this UnitAudio self, AudioClip clip)
        {
            foreach (AudioSource audioSource in self.AudioSources)
            {
                if (audioSource.isPlaying)
                {
                    continue;
                }

                audioSource.PlayOneShot(clip);
                return;
            }
        }
    }
}