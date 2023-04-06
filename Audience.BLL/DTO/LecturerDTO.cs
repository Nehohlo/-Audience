using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audience.BLL.DTO
{
    public class LecturerDTO
    {
        public int Id { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public LecturerDTO(int id, string surName, string name, string patronymic)
        {
            Id = id;
            SurName = surName;
            Name = name;
            Patronymic = patronymic;
        }

        public LecturerDTO(int id)
        {
            Id = id;
        }

        public LecturerDTO() { }
    }
}
