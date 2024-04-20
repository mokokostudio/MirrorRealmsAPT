namespace ET.Server
{
    [Invoke(TimerInvokeType.SpwanMonsterTimer)]
    [FriendOfAttribute(typeof (ET.Server.CreateMonsterInfo))]
    public class CreateMonster_TimerHandler: ATimer<CreateMonsterInfo>
    {
        protected override void Run(CreateMonsterInfo t)
        {
            t.GetParent<MonsterMapComponent>().CreateMonster(t.MonsterId);
        }
    }
}