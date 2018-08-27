namespace Common.Communication.Packet
{
    public interface IPacketRequest
    {
        void Dispatch(ServerSession session, PacketRead packetRead);
    }
}