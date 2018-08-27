namespace Common.Communication
{
    public abstract class ClientSession
    {
        public byte[] CryptographyKey = new byte[] {};
        public byte[] AuthenticKey = new byte[] {};
        
        public abstract void Receive(byte[] buffer, int size);
    }
}