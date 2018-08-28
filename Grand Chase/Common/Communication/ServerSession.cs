using System;
using System.Net.Sockets;
using Common.Attributes;
using Common.Communication.Packet;

namespace Common.Communication
{
    public class ServerSession
    {
        private readonly ServerSocket _serverSocket;
        private readonly Socket _client;
        
        private byte[] _dataBuffer = new byte[65536];
        
        public ClientSession Client { get; private set; }
        
        public string Address => _client.RemoteEndPoint.ToString().Split(':')[0];

        public ServerSession(ServerSocket serverSocket, Socket client)
        {
            _serverSocket = serverSocket;
            _client = client;
        }

        public void SetSession(ClientSession session)
        {
            if (Client != null) return;
            Client = session;
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
                if (bytes > 0)
                {
                    var data = new byte[bytes];
                    Client.Receive(data, bytes);
                    _client.BeginReceive(_dataBuffer, 0, _dataBuffer.Length, SocketFlags.None,
                        BytesReceived, this);
                }
                else
                {
                    _serverSocket.Close(this);
                }
            }
            catch
            {
                _serverSocket.Close(this);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}