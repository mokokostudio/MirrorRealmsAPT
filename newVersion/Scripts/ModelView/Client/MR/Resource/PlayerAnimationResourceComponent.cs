using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public sealed class PlayerAnimationResourceComponent: Entity, IAwake, IDestroy
    {
        public readonly Dictionary<string, CharacterAnimationDataClip> Dict = new();
    }
}