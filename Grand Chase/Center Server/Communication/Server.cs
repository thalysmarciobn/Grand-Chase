using Common.Communication;
using Common.Communication.Packet;
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
            using (var packetWrite = new PacketWrite())
            {
                packetWrite.Short(24787);
                packetWrite.Int(8);
                packetWrite.Bytes(session.Client.DES_KEY);
                packetWrite.Int(8);
                packetWrite.Bytes(session.Client.HMAC_KEY);
                packetWrite.Int(1);
                packetWrite.Int(0);
                packetWrite.Int(0);
                session.Client.Send(packetWrite, Opcodes.Game.SET_SECURITY_KEY_NOT);
            }
            using (var packetWrite = new PacketWrite())
            {
                packetWrite.Short(1000);
                session.Client.Send(packetWrite, Opcodes.Center.ENU_WAIT_TIME_NOT);
            }
        }

        public override void Close(ServerSession session)
        {
            base.Close(session);
            // update sql stats on = 0, etc..
            session.Dispose();
        }
    }
}