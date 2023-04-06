namespace Audience.Models.TimetableOfClasses
{
    public class TimetableOfClassesResponseModel
    {
        public int Id { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
    }
}
