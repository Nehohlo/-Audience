
using Audience.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace Audience.BLL.DTO
{
    public class ClassDTO
    {

        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimetableOfClassesDTO timetableOfClasses { get; set; }

        public string NameGroup { get; set; }
        public AudiencesDTO Audiences { get; set; }
        public LecturerDTO Lecturer { get; set; }
        public bool isNeedMedia { get; set; }

        public ClassDTO(int id, DateOnly date, TimetableOfClassesDTO timetableOfClasses, string nameGroup, AudiencesDTO audiences, LecturerDTO lecturer, bool isNeedMedia)
        {
            Id = id;
            Date = date;
            this.timetableOfClasses = timetableOfClasses;
            NameGroup = nameGroup;
            Audiences = audiences;
            Lecturer = lecturer;
            this.isNeedMedia = isNeedMedia;
        }

        public ClassDTO(LecturerDTO lecturerDTO)
        {
            Lecturer = lecturerDTO;
        }

        public ClassDTO() { }

    }
}
