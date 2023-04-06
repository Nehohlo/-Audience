using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audience.Infrastructure.Services
{
    public class Result
    {
        public bool Success { get; set; }
        public int id { get; set; }

        public bool Failure => !this.Success;

        public string Message { get; set; }

        public static implicit operator Result(bool succeede) =>
            new Result { Success = succeede };

        public static implicit operator Result(string error) =>
            new Result
            {
                Success = false,
                Message = error
            };
    }
}
