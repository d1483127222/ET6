using System;

namespace ET
{
    public class C2R_ReloadDllHandler : AMRpcHandler<C2R_ReloadDll,R2C_ReloadDll>
    {
        protected override async ETTask Run(Session session, C2R_ReloadDll request, R2C_ReloadDll response, Action reply)
        {
            Game.FrameFinishCallback.Add(() =>
            {
                Game.EventSystem.Add(DllHelper.GetHotfixAssembly());
                Game.EventSystem.Load();
                
            });
            reply();
            await ETTask.CompletedTask;
        }
    }
}