using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Common.Log;

namespace Common.Communication
{
    public class ServerSocket : IServer
    {
        private TcpListener _tcpListener;
        private ConcurrentDictionary<ServerSession, string> _connections = new ConcurrentDictionary<ServerSession, string>();
        private bool _running;

        public ServerSocket(ServerSettings serverSettings)
        {
            Logging.Info($"Starting a network on port: {serverSettings.Port}");
            Settings = serverSettings;
        }

        public bool Bind()
        {
            try
            {
                _tcpListener = new TcpListener(IPAddress.Parse(Settings.Address), Settings.Port);
                _tcpListener.Start();
                _tcpListener.Server.Listen(Settings.Backlog);
                return _running = true;
            }
            catch
            {
                Logging.Alert($"Can't bind server on port: {Settings.Port}");
            }

            return false;
        }

        public void BeginAcceptClients()
        {
            if (!_running) return;
            Logging.Info($"Accepting clients on port: {Settings.Port}");
            _tcpListener.BeginAcceptTcpClient(AcceptConnection, null);
        }

        private void AcceptConnection(IAsyncResult iAsyncResult)
        {
            lock (_connections)
            {
                var client = _tcpListener.EndAcceptTcpClient(iAsyncResult);
                var session = new ServerSession(client);
                if (_connections.Count >= Settings.Limit) return;
                if (ConnectionsByAddress(session.Address) > Settings.LimitPerAddress) return;
                if (_connections.TryAdd(session, session.Address))
                {
                    Accept(session);
                }
            }
        }

        public ServerSettings Settings { get; }

        public int ConnectionsByAddress(string address)
        {
            return _connections.Count(x => x.Value == address);
        }

        public virtual void Accept(ServerSession session)
        {
            Logging.Server($"New connection: {session.Address}");
        }

        public virtual void Close(ServerSession session)
        {
            Logging.Server($"New connection: {session.Address}");
        }
    }
}