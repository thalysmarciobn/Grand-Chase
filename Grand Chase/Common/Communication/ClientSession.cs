using Common.Communication.Packet;

namespace Common.Communication
{
    public abstract class ClientSession
    {
        public byte[] DES_KEY = { 0xC7, 0xD8, 0xC4, 0xBF, 0xB5, 0xE9, 0xC0, 0xFD };
        public byte[] HMAC_KEY = { 0xC0, 0xD3, 0xBD, 0xC3, 0xB7, 0xCE, 0xB8, 0xB8 };
        public byte[] PREFIX = new byte[2];
        
        public abstract void Receive(byte[] buffer, int size);

        public void Send(PacketWrite write, Opcodes.Center opcode, bool compressed = false, short prefix = -1)
        {
            Send(write, (short) opcode, compressed, prefix);
        }

        public void Send(PacketWrite write, Opcodes.Game opcode, bool compressed = false, short prefix = -1)
        {
            Send(write, (short) opcode, compressed, prefix);
        }
        
        public void Send(PacketWrite write, short opcode, bool compressed, short prefix)
        {
            using (var packetWrite = new PacketWrite())
            {
                packetWrite.Short(opcode);
                packetWrite.Int(write.Length);
                packetWrite.Bool(compressed);
                packetWrite.Bytes(write.Packet);
            }
        }
    }
}