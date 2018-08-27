using System.Security.Cryptography;

namespace Common.Communication
{
    public abstract class ClientSession
    {
        public byte[] GC_DES_KEY = { 0xC7, 0xD8, 0xC4, 0xBF, 0xB5, 0xE9, 0xC0, 0xFD };;
        public byte[] HMAC_KEY = { 0xC0, 0xD3, 0xBD, 0xC3, 0xB7, 0xCE, 0xB8, 0xB8 };;
        public int HMAC_SIZE = 10;
        
        public abstract void Receive(byte[] buffer, int size);
    }
}