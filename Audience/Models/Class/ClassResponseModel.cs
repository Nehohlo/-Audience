using Audience.BLL.DTO;
using Audience.DAL.Entities;
using Audience.Models.Audiences;
using Audience.Models.Lecturer;
using Audience.Models.TimetableOfClasses;

namespace Audience.Models.Class
{
    public class ClassResponseModel
    {
        public DateOnly Date { get; set; }
        public TimetableOfClassesResponseModel timetableOfClasses { get; set; }
        public string NameGroup { get; set; }
        public AudiencesResponseModel Audiences { get; set; }
        public LecturerResponseModel Lecturer { get; set; }
        public bool isNeedMedia { get; set; }
    }
}
