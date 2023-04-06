using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audience.DAL.Entities
{
    public class TimetableOfClasses
    {
        [Key]
        public int Id { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
        public IEnumerable<Class> ItemsClass { get; set; }
    }
}
