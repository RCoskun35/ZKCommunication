namespace NLayer.Core
{
    public class EventData : BaseEntity
    {
        public DateTime EventTime { get; set; }
        public int EventType { get; set; }
        public int TerminalId { get; set; }
        public int UserRecNo { get; set; }
    }
}
