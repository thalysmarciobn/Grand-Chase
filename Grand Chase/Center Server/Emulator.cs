using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Center_Server.Communication;
using Common.Communication;
using Common.Log;

namespace Center_Server
{
    public class Emulator
    {
        private static readonly ServerSettings[] Servers = 
        {
            new ServerSettings() { Address = "127.0.0.1", Port = 9500, Limit = 1000, LimitPerAddress = 2, Backlog = 100 },
            new ServerSettings() { Address = "127.0.0.1", Port = 9501, Limit = 1000, LimitPerAddress = 2, Backlog = 100 }
        };

        private static readonly List<ServerSocket> _servers = new List<ServerSocket>();
        
        public static void Main(string[] args)
        {
            Logging.Info("Starting center server...");
            foreach (var setting in Servers)
            {
                var networkServer = new Server(setting);
                if (networkServer.Bind())
                {
                    _servers.Add(networkServer);
                }
            }
            foreach (var server in _servers)
            {
                server.BeginAcceptClients();
            }
            while (true)
            {
                Thread.Sleep(50);
            }
        }
    }
}