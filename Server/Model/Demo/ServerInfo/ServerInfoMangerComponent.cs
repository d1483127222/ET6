using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    [ChildType(typeof(ServerInfo))]
    public class ServerInfoMangerComponent : Entity,IAwake,IDestroy,ILoad
    {
        public List<ServerInfo> ServerInfos = new List<ServerInfo>();
    }
}