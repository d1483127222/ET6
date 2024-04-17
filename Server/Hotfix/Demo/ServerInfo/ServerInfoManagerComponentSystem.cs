namespace ET
{
    public class ServerInfoManagerComponentAwakeSystem : AwakeSystem<ServerInfoMangerComponent>
    {
        public override void Awake(ServerInfoMangerComponent self)
        {
            self.Awake().Coroutine();
        }
    }
    
    public class ServerInfoManagerComponentDestroySystem : DestroySystem<ServerInfoMangerComponent>
    {
        public override void Destroy(ServerInfoMangerComponent self)
        {
            foreach (var serverInfo in self.ServerInfos)
            {
                serverInfo?.Dispose();
            }
            self.ServerInfos.Clear();
        }
    }
    
    public class ServerInfoManagerComponentLoadSystem : LoadSystem<ServerInfoMangerComponent>
    {
        public override void Load(ServerInfoMangerComponent self)
        {
            self.Awake().Coroutine();
        }
    }
    [FriendClassAttribute(typeof(ET.ServerInfoMangerComponent))]
    [FriendClassAttribute(typeof(ET.ServerInfo))]
    public static class ServerInfoManagerComponentSystem
    {
        public static async ETTask Awake(this ServerInfoMangerComponent self)
        {
            var serverInfoList = await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Query<ServerInfo>(d => true);
            if (serverInfoList == null || serverInfoList.Count <= 0)
            {
                Log.Error("ServerInfo count is zero");



                self.ServerInfos.Clear();
                var serverInfoConfigs = ServerInfoConfigCategory.Instance.GetAll();
                foreach (var info in serverInfoConfigs.Values)
                {
                    ServerInfo newServerInfo = self.AddChildWithId<ServerInfo>(info.Id);
                    newServerInfo.ServerName = info.ServerName;
                    newServerInfo.Status = (int)ServerStatus.Normal;
                    self.ServerInfos.Add(newServerInfo);
                    await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Save(newServerInfo);
                }

                return;
            }
            self.ServerInfos.Clear();
            foreach (var serverInfo in serverInfoList)
            {
                self.AddChild(serverInfo);
                self.ServerInfos.Add(serverInfo);
            }

            await ETTask.CompletedTask;
        }

    }
}