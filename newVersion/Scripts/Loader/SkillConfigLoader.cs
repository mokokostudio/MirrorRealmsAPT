using MongoDB.Bson;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ET
{
    [Invoke]
    public class SkillConfigLoader: AInvokeHandler<SkillConfigComponent.GetAllSkillConfigBytes, ETTask<Dictionary<string, byte[]>>>
    {
        public override async ETTask<Dictionary<string, byte[]>> Handle(SkillConfigComponent.GetAllSkillConfigBytes args)
        {
            Dictionary<string, byte[]> output = new Dictionary<string, byte[]>();
            if (Define.IsEditor)
            {
                string dir = Path.Combine("../Config/SkillConfig");
                string[] files = Directory.GetFiles(dir, "*.bytes");
                foreach (string file in files)
                {
                    output[Path.GetFileNameWithoutExtension(file)] = File.ReadAllBytes(file);
                }
            }
            //else
            //{
            //    // TODO:   2024.01.22
            //    string[] filesNameAry = new string[] {
            //        "Girl_Bow_Atk",
            //        "Girl_Bow_Atk_1A",
            //        "Girl_Bow_Atk_2B",
            //        "Girl_Bow_Atk_3B",
            //        "Girl_Bow_Atk_R",
            //        "Girl_Bow_Atk_R_1A",
            //        "Girl_Bow_Atk_R_1A_BK",
            //        "Girl_Bow_Atk_R_2B",
            //        "Girl_Bow_Atk_R_BK",
            //        "Girl_Bow_Hit_B",
            //        "Girl_Bow_Hit_F",
            //        "Girl_Bow_Hit_L",
            //        "Girl_Bow_Hit_R",
            //        "Girl_Bow_Idle",
            //        "Girl_Bow_RunAim1_B",
            //        "Girl_Bow_RunAim1_BL",
            //        "Girl_Bow_RunAim1_BR",
            //        "Girl_Bow_RunAim1_F",
            //        "Girl_Bow_RunAim1_FL",
            //        "Girl_Bow_RunAim1_FR",
            //        "Girl_Bow_RunAim1_L",
            //        "Girl_Bow_RunAim1_R",
            //        "Girl_Bow_Run_B",
            //        "Girl_Bow_Run_BL",
            //        "Girl_Bow_Run_BR",
            //        "Girl_Bow_Run_F",
            //        "Girl_Bow_Run_FL",
            //        "Girl_Bow_Run_FR",
            //        "Girl_Bow_Run_L",
            //        "Girl_Bow_Run_R",
            //        "Girl_Bow_Slide_F",
            //        "Girl_Bow_Sprint",
            //        "Girl_Bow_Sprint_Stop",
            //        "Girl_Common_Click_Abdomen",
            //        "Girl_Common_Click_Arm",
            //        "Girl_Common_Click_Chest",
            //        "Girl_Common_Click_Crotch",
            //        "Girl_Common_Click_FootLR",
            //        "Girl_Common_Click_Hair",
            //        "Girl_Common_Click_Waist",
            //        "Girl_Common_Die_FL",
            //        "Girl_Common_Die_Large_B",
            //        "Girl_Common_Enter_Fight",
            //        "Girl_Common_Equip_Bow",
            //        "Girl_Common_Equip_Dagger",
            //        "Girl_Common_Equip_GreatSword",
            //        "Girl_Common_Equip_SwordShield",
            //        "Girl_Common_Equip_TwinDaggers",
            //        "Girl_Common_Hit_F",
            //        "Girl_Common_Hit_Large",
            //        "Girl_Common_Idle",
            //        "Girl_Common_Run_B",
            //        "Girl_Common_Run_BL",
            //        "Girl_Common_Run_BR",
            //        "Girl_Common_Run_F",
            //        "Girl_Common_Run_FL",
            //        "Girl_Common_Run_FR",
            //        "Girl_Common_Run_L",
            //        "Girl_Common_Run_R",
            //        "Girl_Common_Slide_F",
            //        "Girl_Common_Sprint",
            //        "Girl_Common_Sprint_End_L",
            //        "Girl_Common_Sprint_End_R",
            //        "Girl_Common_Sprint_Stop",
            //        "Girl_GreatSword_Atk",
            //        "Girl_GreatSword_Atk_1A",
            //        "Girl_GreatSword_Atk_1A1A",
            //        "Girl_GreatSword_Atk_1A1A1B",
            //        "Girl_GreatSword_Atk_2B",
            //        "Girl_GreatSword_Atk_3B",
            //        "Girl_GreatSword_Atk_D",
            //        "Girl_GreatSword_Atk_Defense",
            //        "Girl_GreatSword_Atk_D_1A",
            //        "Girl_GreatSword_Defense_Cast",
            //        "Girl_GreatSword_Defense_Hit",
            //        "Girl_GreatSword_Defense_Shock",
            //        "Girl_GreatSword_Defense_Success",
            //        "Girl_GreatSword_Hit_F",
            //        "Girl_GreatSword_Idle",
            //        "Girl_GreatSword_Run_B",
            //        "Girl_GreatSword_Run_BL",
            //        "Girl_GreatSword_Run_BR",
            //        "Girl_GreatSword_Run_F",
            //        "Girl_GreatSword_Run_FL",
            //        "Girl_GreatSword_Run_FR",
            //        "Girl_GreatSword_Run_L",
            //        "Girl_GreatSword_Run_R",
            //        "Girl_GreatSword_Slide_F",
            //        "Girl_GreatSword_Sprint",
            //        "Girl_GreatSword_Sprint_Stop",
            //        "Girl_GreatSword_SwordShield_Atk_D",
            //        "Girl_GreatSword_S_1",
            //        "Girl_GreatSword_S_2",
            //        "Girl_GreatSword_S_3",
            //        "Girl_GreatSword_S_4",
            //        "Girl_GreatSword_S_5",
            //        "Girl_GreatSword_S_6",
            //        "Girl_GreatSword_S_7",
            //        "Girl_GreatSword_S_8",
            //        "Girl_GreatSword_S_9",
            //        "Girl_SwordShield_Atk",
            //        "Girl_SwordShield_Atk_1A",
            //        "Girl_SwordShield_Atk_1A1A",
            //        "Girl_SwordShield_Atk_1A1A1B",
            //        "Girl_SwordShield_Atk_2B",
            //        "Girl_SwordShield_Atk_3B",
            //        "Girl_SwordShield_Atk_D",
            //        "Girl_SwordShield_Atk_Defense",
            //        "Girl_SwordShield_Atk_D_1A",
            //        "Girl_SwordShield_Defense_Cast",
            //        "Girl_SwordShield_Defense_Hit",
            //        "Girl_SwordShield_Defense_Shock",
            //        "Girl_SwordShield_Defense_Success",
            //        "Girl_SwordShield_Hit_F",
            //        "Girl_SwordShield_Idle",
            //        "Girl_SwordShield_Run_B",
            //        "Girl_SwordShield_Run_BL",
            //        "Girl_SwordShield_Run_BR",
            //        "Girl_SwordShield_Run_F",
            //        "Girl_SwordShield_Run_FL",
            //        "Girl_SwordShield_Run_FR",
            //        "Girl_SwordShield_Run_L",
            //        "Girl_SwordShield_Run_R",
            //        "Girl_SwordShield_Slide_F",
            //        "Girl_SwordShield_Sprint",
            //        "Girl_SwordShield_Sprint_Stop"};
            //    foreach (string name in filesNameAry)
            //    {
            //        string path = $"Assets/Bundles/SkillConfig/{name}.bytes";
            //        TextAsset ta = await ResourcesComponent.Instance.LoadAssetAsync<TextAsset>(path);
            //        output[name] = ta.ToBson();
            //    }
            //}

            await ETTask.CompletedTask;
            return output;
        }
    }
}