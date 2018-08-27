using System;
using System.Net;
using System.Net.Sockets;
using Common.Log;

namespace Common.Communication
{
    public class ServerSocket<T> : IServer
    {
        private TcpListener _tcpListener;

        public ServerSocket(IServer server) : base(server.Settings)
        {
            Logging.Info($"Starting server on port: {server.Settings.Port}");
        }

        public void Bind()
        {
            _tcpListener = new TcpListener(IPAddress.Parse(Settings.Address), Settings.Port);
            _tcpListener.Start();
            _tcpListener.Server.Listen(Settings.Backlog);
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

        public override void Receive(byte[] buffer, int size)
        {
            throw new NotImplementedException();
        }

        public override void Accept(ServerSession session)
        {
            throw new NotImplementedException();
        }

        public override void Close(ServerSession session)
        {
            throw new NotImplementedException();
        }
    }
}