using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Common.Communication.Packet
{
    public class PacketWrite : IDisposable
    {
       
        private List<byte> _bytes = new List<byte>();
        
        public byte[] Packet => _bytes.ToArray();

        public int Length => _bytes.ToArray().Length;
        
        public void Byte(byte _byte)
        {
            IncludeList(new[] { _byte });
        }
        
        public void Short(short _short)
        {
            var bytes = new byte[sizeof(short)];
            bytes[0] = (byte)(_short >> 8);
            bytes[1] = (byte)(_short);
            IncludeList(bytes);
        }
        
        public void UShort(short _short)
        {
            var bytes = new byte[sizeof(ushort)];
            bytes[0] = (byte)(_short >> 8);
            bytes[1] = (byte)(_short);
            IncludeList(bytes);
        }
        
        public void Int(int _int){
            var bytes = new byte[sizeof(int)];
            bytes[0] = (byte)(_int >> 24);
            bytes[1] = (byte)(_int >> 16);
            bytes[2] = (byte)(_int >> 8);
            bytes[3] = (byte)(_int);
            IncludeList(bytes);
        }
        
        public void UInt(int _int){
            var bytes = new byte[sizeof(uint)];
            bytes[0] = (byte)(_int >> 24);
            bytes[1] = (byte)(_int >> 16);
            bytes[2] = (byte)(_int >> 8);
            bytes[3] = (byte)(_int);
            IncludeList(bytes);
        }
        
        public void Long(long _long){
            var bytes = new byte[sizeof(long)];
            bytes[0] = (byte)(_long >> 56);
            bytes[1] = (byte)(_long >> 48);
            bytes[2] = (byte)(_long >> 40);
            bytes[3] = (byte)(_long >> 32);
            bytes[4] = (byte)(_long >> 24);
            bytes[5] = (byte)(_long >> 16);
            bytes[6] = (byte)(_long >> 8);
            bytes[7] = (byte)(_long);
            IncludeList(bytes);
        }
        
        public void Bool(bool _bool){
            IncludeList(new[] { Convert.ToByte(_bool) });
        }
        
        public void String(string str){
            Int(str.Length);
            IncludeList(Encoding.ASCII.GetBytes(str));
        }
        
        public void UnicodeString(string _string){
            Int(_string.Length * 2);
            IncludeList(Encoding.Unicode.GetBytes(_string));
        }
        
        public void WriteAddress(string address, bool reverse)
        {
            var addressBytes = IPAddress.Parse(address).GetAddressBytes();
            if (reverse)
            {
                Array.Reverse(addressBytes);
            }
            Bytes(addressBytes);
        }
        
        public void Bytes(byte[] bytes){
            IncludeList(bytes);
        }
        
        public void Hex(string hexBytes)
        {
            for(var i = 0; i < hexBytes.Length / 2; i++)
            {
                Byte(Convert.ToByte(hexBytes.Substring(i * 2, 2), 16));
            }   
        }
        
        private void IncludeList(byte[] data){
            _bytes.AddRange(data);
        }

        public void Dispose()
        {
            _bytes = null;
        }
    }
}