namespace NLayer.Core.DTOs
{
    public class UserDto : BaseDto
    {


        public int UserRecNo { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int CardNo { get; set; }
        public string Face { get; set; }
        public string FingerPrint1 { get; set; }
        public string FingerPrint2 { get; set; }
    }
}
