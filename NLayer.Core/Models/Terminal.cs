namespace NLayer.Core
{
    public class Terminal : BaseEntity
    {
        public string IpAdress { get; set; }
        public int Port { get; set; }
        public string Name { get; set; }

        public DateTime LastConnectDate { get; set; }
    }
}
