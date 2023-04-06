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
    public interface IClassServices
    {
        Task<Result> Create(ClassDTO audience);
        Task<List<ClassDTO>> GetAll();
        Task<ClassDTO> Get(int id);
        Task<Result> Delete(int id);

        Task<List<ClassDTO>> GetDate(DateOnly date);
    }
}
