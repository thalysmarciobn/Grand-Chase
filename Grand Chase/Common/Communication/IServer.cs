namespace Common.Communication
{
    public interface IServer
    {
        ServerSettings Settings { get; }
        
        void Accept(ServerSession session);

        void Close(ServerSession session);

        int ConnectionsByAddress(string address);
    }
}