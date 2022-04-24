namespace NLayer.Core.DTOs
{
    public class EventDataDto : BaseDto
    {


        public DateTime EventTime { get; set; }
        public int EventType { get; set; }
        public int TerminalId { get; set; }
        public int UserRecNo { get; set; }
    }
}
