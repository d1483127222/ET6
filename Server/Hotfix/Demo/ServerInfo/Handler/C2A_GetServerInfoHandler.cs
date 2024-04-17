using System;

namespace ET.Handler
{
    [FriendClassAttribute(typeof(ET.ServerInfoMangerComponent))]
    public class C2A_GetServerInfoHandler : AMRpcHandler<C2A_GetServerInfos, A2C_GetServerInfos>
    {
        protected override async ETTask Run(Session session, C2A_GetServerInfos request, A2C_GetServerInfos response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error($"请求的scene错误，当前scene为：{session.DomainScene().SceneType}");
                session?.Disconnect().Coroutine();
                return;
            }

            string token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);

            if (token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session?.Disconnect().Coroutine();
                return;
            }

            foreach (var serverInfo in session.DomainScene().GetComponent<ServerInfoMangerComponent>().ServerInfos)
            {
                response.ServerInfosList.Add(serverInfo.ToMessage());
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}