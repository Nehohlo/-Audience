using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audience.DAL.Entities
{
    public class Audiences
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        public bool IsHaveMedia { get; set; } = false;

        public IEnumerable<Class> ItemsClass { get; set; }
    }
}
