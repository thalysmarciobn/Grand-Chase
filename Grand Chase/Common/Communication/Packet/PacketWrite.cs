using System;
using System.Collections.Generic;
using Common.Utilities.BigEndian;

namespace Common.Communication.Packet
{
    public class PacketWrite : IDisposable
    {
        private int _position { get; set; }
        private List<byte> _bytes = new List<byte>();
        public BigEndian BigEndian = new BigEndian();

        private byte[] Bytes => _bytes.ToArray();
        
        private void Include(byte[] data){
            _bytes.AddRange(data);
            _position += data.Length;
        }
        
        public void Int(int int32){
            Include(BigEndian.GetBytes(int32));
        }

        public void Dispose()
        {
            _position = 0;
            _bytes = null;
        }
    }
}