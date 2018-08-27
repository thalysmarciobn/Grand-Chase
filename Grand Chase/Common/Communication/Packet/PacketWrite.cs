using System.Collections.Generic;

namespace Common.Communication.Packet
{
    public class PacketWrite
    {
        private int _position = 0;
        
        private List<byte> _bytes = new List<byte>();
        
        private byte[] GetPacket => _bytes.ToArray();
        
        private void IncludeList(byte[] data){
            _bytes.AddRange(data);
            _position += data.Length;
        }
    }
}