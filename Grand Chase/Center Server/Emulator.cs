using System.Threading;
using Common.Communication;

namespace Center_Server
{
    public class Emulator
    {
        private static readonly ServerSettings[] Servers = 
        {
            new ServerSettings() { Address = "127.0.0.1", Port = 9500, Limit = 1000, Backlog = 100 },
            new ServerSettings() { Address = "127.0.0.1", Port = 9501, Limit = 1000, Backlog = 100 }
        };
        
        public static void Main(string[] args)
        {
            foreach (var setting in Servers)
            {
                var networkServer = new ServerSocket(setting);
                networkServer.Bind();
            }

            while (true)
            {
                Thread.Sleep(50);
            }
        }
    }
}