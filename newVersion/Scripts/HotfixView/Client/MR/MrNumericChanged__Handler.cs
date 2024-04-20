using ET.EventType;
using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Current)]
    public class MrNumericChanged__Handler: AEvent<Scene, NumericChanged>
    {
        protected override async ETTask Run(Scene scene, NumericChanged a)
        {
            // UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            //
            // var unit = unitComponent.Get(a.UnitId);
            // if (unit == null)
            // {
            //     return;
            // }
            //
            // var pos = unit.Position + new float3(0, 1.5f, 0);
            // var name = a.NumericType switch
            // {
            //     NumericType.Attack => $"Attack",
            //     NumericType.DamageReduction => $"DamageReduction",
            //     NumericType.Speed => $"Speed",
            //     _ => $"unknown numeric type: {a.NumericType}"
            // };
            //
            // var desc = a.NewValue > a.OldValue? "Up" : "Down";
            // var text = $"{name} {desc}";
            //
            // var fontSize = 18;
            // var color = a.NewValue > a.OldValue? Color.green : Color.red;
            //
            // var com = scene.GetComponent<ShowFloatingTextComponent>();
            // com.Create(pos, text, fontSize, color);
    
            await ETTask.CompletedTask;
        }

    }
}