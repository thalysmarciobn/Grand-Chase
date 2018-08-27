namespace Common.Communication
{
    public abstract class IServer
    {
        public ServerSettings Settings { get; private set; }

        protected IServer(ServerSettings settings)
        {
            Settings = settings;
        }

        public abstract void Receive(byte[] buffer, int size);
        public abstract void Accept(ServerSession session);
        public abstract void Close(ServerSession session);
    }
}