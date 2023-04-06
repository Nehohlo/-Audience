using Audience.Infrastructure.Converter;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Audience.Models.Class
{
    public class ClassGetDateRequestModel
    {
        [Range(2000, 2200)]
        public int Year { get; set; }
        [Range(1, 12)]
        public int Month { get; set; }
        [Range(1, 31)]
        public int Day { get; set; }
    }
}
