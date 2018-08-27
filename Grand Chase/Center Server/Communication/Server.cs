using Common.Communication;

namespace Center_Server.Communication
{
    public class Server : IServer
    {

        public Server(ServerSettings settings) : base(settings)
        {
        }
        
        public override void Receive(byte[] buffer, int size)
        {
        }

        public override void Accept(ServerSession session)
        {
        }

        public override void Close(ServerSession session)
        {
        }
    }
}