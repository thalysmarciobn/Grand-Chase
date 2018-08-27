using System;
using System.Net.Sockets;
using Common.Attributes;

namespace Common.Communication
{
    public class ServerSession
    {
        private readonly ServerSocket _serverSocket;
        private readonly Socket _client;

        private bool _reading = false;
        
        private byte[] _dataBuffer;
        
        public ClientSession Client { get; private set; }
        
        public string Address => _client.RemoteEndPoint.ToString().Split(':')[0];

        public ServerSession(ServerSocket serverSocket, Socket client)
        {
            _serverSocket = serverSocket;
            _client = client;
        }

        public void SetSession(ClientSession session)
        {
            Client = session;
        }

        public void StartRead()
        {
            if (_reading) return;
            try
            {
                _client.BeginReceive(_dataBuffer, 0, _dataBuffer.Length, SocketFlags.None,
                    BytesReceived, this);
            }
            catch
            {
                _serverSocket.Close(this);
            }
        }

        private void BytesReceived(IAsyncResult iAr)
        {
            try
            {
                var bytes = _client.EndReceive(iAr);
                var data = new byte[bytes];
            }
            catch
            {
                _serverSocket.Close(this);
            }
        }
    }
}