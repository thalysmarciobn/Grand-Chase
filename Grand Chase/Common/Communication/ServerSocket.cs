using System;
using System.Net;
using System.Net.Sockets;

namespace Common.Communication
{
    public class ServerSocket
    {
        private TcpListener _tcpListener;
        private readonly ServerSettings _serverSettings;

        public ServerSocket(ServerSettings settings)
        {
            _serverSettings = settings;
        }

        public void Bind()
        {
            _tcpListener = new TcpListener(IPAddress.Parse(_serverSettings.Address), _serverSettings.Port);
            _tcpListener.Start();
            _tcpListener.Server.Listen(_serverSettings.Backlog);
            try
            {
                _tcpListener.BeginAcceptTcpClient(AcceptConnection, null);
            }
            catch
            {
                
            }
        }

        public void AcceptConnection(IAsyncResult iAsyncResult)
        {
            var client = _tcpListener.EndAcceptTcpClient(iAsyncResult);
        }
    }
}