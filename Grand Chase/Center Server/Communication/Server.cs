using Common.Communication;
using Common.Log;

namespace Center_Server.Communication
{
    public class Server : ServerSocket
    {
        private ServerSettings _settings;

        public Server(ServerSettings settings) : base(settings)
        {
            _settings = settings;
        }

        public override void Accept(ServerSession session)
        {
            base.Accept(session);
            session.SetSession(new Session());
        }

        public override void Close(ServerSession session)
        {
        }
    }
}