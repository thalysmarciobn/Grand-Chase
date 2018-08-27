using System.Security.Cryptography;

namespace Common.Communication
{
    public abstract class ClientSession
    {
        public byte[] GC_DES_KEY;
        public byte[] HMAC_KEY;

        public ClientSession()
        {
            GC_DES_KEY = Generate();
            HMAC_KEY = Generate();
        }

        private byte[] Generate()
        {
            var bytes = new byte[8];
            var cryptoServiceProvider = new RNGCryptoServiceProvider();
            cryptoServiceProvider.GetBytes(bytes);
            return bytes;
        }
        
        public abstract void Receive(byte[] buffer, int size);
    }
}