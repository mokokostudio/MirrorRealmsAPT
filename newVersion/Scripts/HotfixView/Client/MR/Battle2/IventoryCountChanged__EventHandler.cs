using ET.EventType;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class IventoryCountChanged__EventHandler: AEvent<Scene, IventoryCountChanged>
    {
        protected override async ETTask Run(Scene scene, IventoryCountChanged a)
        {
            Log.Console($"IventoryCountChanged: {a.ItemConfigId} - {a.OldCount} -> {a.NewCount}");

            var ui = scene.GetComponent<UIComponent>();
            var ui_b = ui.Get(MrUIType.UIBattle);
            // 有可能还没创建UIBattle
            if (ui_b != null)
            {
                var bc = ui_b.GetComponent<UIBattleComponent>();

                var ip = bc.GetComponent<UIBattleComponent_InventoryPanel>();
                ip.OnCountChanged(a.ItemConfigId, a.OldCount, a.NewCount);

                var rp = bc.GetComponent<UIBattleComponent_RunePanel>();

                rp.OnIventoryCountChanged(a.ItemConfigId, a.OldCount, a.NewCount);

                if (a.NewCount > a.OldCount)
                {
                    var gitp = bc.GetComponent<UIBattleComponent_GetItemTipPanel>();
                    gitp.Create(a.ItemConfigId, a.NewCount - a.OldCount);
                }
            }

            // 获得物品飘字
            // if (a.NewCount > a.OldCount)
            // {
            //     var count = a.NewCount - a.OldCount;
            //
            //     var com = scene.GetComponent<ShowFloatingTextComponent>();
            //     if (com != null)
            //     {
            //         var unitPos = MrUnitHelper.GetMyUnitFromCurrentScene(scene).Position;
            //         var pos = new float3(unitPos.x, unitPos.y + 1f, unitPos.z);
            //         var showName = ItemConfigCategory.Instance.Get(a.ItemConfigId).ShowName;
            //         var text = $"Get [{showName}] x {count}";
            //         var fontSize = 14;
            //         var color = Color.cyan;
            //         com.Create(pos, text, fontSize, color);
            //     }
            // }

            await ETTask.CompletedTask;
        }
    }
}