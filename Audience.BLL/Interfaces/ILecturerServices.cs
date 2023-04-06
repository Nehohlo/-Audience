using Audience.BLL.DTO;
using Audience.DAL.Entities;
using Audience.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audience.BLL.Interfaces
{
    public interface ILecturerServices
    {
        Task<Result> Create(LecturerDTO lecturer);
        Task<IEnumerable<LecturerDTO>> GetAll();
        Task<LecturerDTO> Get(int id);
        Task<Result> Delete(int id);
    }
}
