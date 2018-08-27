namespace Common.Communication
{
    public class ServerSettings
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public int Limit { get; set; }
        public int Backlog { get; set; }
    }
}