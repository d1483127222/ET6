namespace ET
{
    public class AccountSessionsComponentDestorySystem : DestroySystem<AccountSessionsComponent>
    {
        public override void Destroy(AccountSessionsComponent self)
        {
            self.AccountSessionDictionary.Clear();
        }
    }
    [FriendClassAttribute(typeof(ET.AccountSessionsComponent))]
    public static class AccountSessionsComponentSystem
    {
        public static long Get(this AccountSessionsComponent self, long accountId)
        {
            if (!self.AccountSessionDictionary.TryGetValue(accountId, out long instanceid))
            {
                return 0;
            }

            return instanceid;
        }

        public static void Add(this AccountSessionsComponent self, long accountId, long sessionInstanced)
        {
            if (self.AccountSessionDictionary.ContainsKey(sessionInstanced))
            {
                self.AccountSessionDictionary[accountId] = sessionInstanced;
                return;
            }
            self.AccountSessionDictionary.Add(accountId, sessionInstanced);
        }

        public static void Remove(this AccountSessionsComponent self, long accountId)
        {
            if (self.AccountSessionDictionary.ContainsKey(accountId))
            {
                self.AccountSessionDictionary.Remove(accountId);
            }
        }
    }


}