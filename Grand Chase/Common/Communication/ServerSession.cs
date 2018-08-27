using System.Net.Sockets;
using Common.Attributes;

namespace Common.Communication
{
    public class ServerSession
    {
        private readonly TcpClient _client;
        
        public ClientSession Client { get; private set; }
        
        public string Address => _client.Client.RemoteEndPoint.ToString().Split(':')[0];

        public ServerSession(TcpClient client)
        {
            _client = client;
        }

        public void SetSession(ClientSession session)
        {
            Client = session;
        }
    }
}