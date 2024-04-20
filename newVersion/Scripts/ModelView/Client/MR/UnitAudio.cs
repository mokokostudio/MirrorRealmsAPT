using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class UnitAudio: Entity, IAwake, IDestroy
    {
        public AudioSource[] AudioSources;
    }
}