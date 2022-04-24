namespace NLayer.Core.DTOs
{
    public class TerminalDto : BaseDto
    {


        public string IpAdress { get; set; }
        public int Port { get; set; }
        public string Name { get; set; }

        public DateTime LastConnectDate { get; set; }
    }
}
