using System.Collections.Concurrent;

namespace Common.Communication.Packet
{
    public class PacketManager
    {
        
        private readonly ConcurrentDictionary<Opcodes, IPacketRequest> Requests = new ConcurrentDictionary<Opcodes, IPacketRequest>();
    }
}