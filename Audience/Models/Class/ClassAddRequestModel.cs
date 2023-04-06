using Audience.Models.Audiences;
using Audience.Models.Lecturer;
using Audience.Models.TimetableOfClasses;
using System.ComponentModel.DataAnnotations;

namespace Audience.Models.Class
{
    public class ClassAddRequestModel
    {
        [Range(2000, 2200)]
        public int Year { get; set; }
        [Range(1, 12)]
        public int Month { get; set; }
        [Range(1, 31)]
        public int Day { get; set; }
        public int TimetableOfClassesId { get; set; }
        public string NameGroup { get; set; }
        public int AudienceId { get; set; }
        public int LecturerId { get; set; }
        public bool isNeedMedia { get; set; }
    }
}
