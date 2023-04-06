using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audience.DAL.Entities
{
    public class Lecturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public IEnumerable<Class> ItemsClass { get; set; }


    }
}
