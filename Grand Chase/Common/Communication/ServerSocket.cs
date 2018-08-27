using System;
using System.Net;
using System.Net.Sockets;
using Common.Log;

namespace Common.Communication
{
    public class ServerSocket<T> : IServer
    {
        private TcpListener _tcpListener;
        private bool _running;

        public ServerSocket(IServer server) : base(server.Settings)
        {
            Logging.Info($"Starting a network on port: {server.Settings.Port}");
        }

        public bool Bind()
        {
            try
            {
                _tcpListener = new TcpListener(IPAddress.Parse(Settings.Address), Settings.Port);
                _tcpListener.Start();
                _tcpListener.Server.Listen(Settings.Backlog);
                _running = true;
                return _running;
            }
            catch
            {
                Logging.Info($"Can't bind server on port: {Settings.Port}");
            }

            return false;
        }

        public void BeginAcceptClients()
        {
            if (_running)
            {
                Logging.Info($"Accepting clients on port: {Settings.Port}");
                _tcpListener.BeginAcceptTcpClient(AcceptConnection, null);
            }
            else
            {
                Logging.Info($"Can't accept clients on port: {Settings.Port}");
            }
        }

        private void AcceptConnection(IAsyncResult iAsyncResult)
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