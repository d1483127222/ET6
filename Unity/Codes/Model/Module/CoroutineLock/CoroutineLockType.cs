namespace ET
{
    public static class CoroutineLockType
    {
        public const int None = 0;
        public const int Location = 1;                  // location进程上使用
        public const int ActorLocationSender = 2;       // ActorLocationSender中队列消息 
        public const int Mailbox = 3;                   // Mailbox中队列
        public const int UnitId = 4;                    // Map服务器上线下线时使用
        public const int DB = 5;
        public const int Resources = 6;
        public const int ResourcesLoader = 7;
        public const int LoadUIBaseWindows = 8;

        public const int LoginAccount = 9;//锁登录账号

        public const int LoginCenterLock = 10;//锁登录中心服账号
        
        public const int GateLoginLock = 11;//锁gate服务器登录账号

        public const int CreateRole = 12;//创建角色
        

        public const int Max = 100; // 这个必须最大
    }
}