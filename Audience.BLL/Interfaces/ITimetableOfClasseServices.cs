using Audience.BLL.DTO;
using Audience.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audience.BLL.Interfaces
{
    public interface ITimetableOfClasseServices
    {
        Task<IEnumerable<TimetableOfClassesDTO>> GetAll();
        Task<TimetableOfClassesDTO> Get(int id);
    }
}
