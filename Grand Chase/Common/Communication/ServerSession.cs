using System.Net.Sockets;
using Common.Attributes;

namespace Common.Communication
{
    public class ServerSession
    {
        private readonly TcpClient _client;
        
        public string Address => _client.Client.RemoteEndPoint.ToString().Split(':')[0];

        public ServerSession(TcpClient client)
        {
            _client = client;
        }
    }
}