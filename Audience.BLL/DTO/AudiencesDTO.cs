using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audience.BLL.DTO
{
    public class AudiencesDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public bool IsHaveMedia { get; set; }
    }
}
