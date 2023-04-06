using Audience.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audience.DAL.Interfaces
{
    public interface IClassRepository : IRepository<Class>
    {
        Task<IEnumerable<Class>> GetDate(DateOnly date);

        Task<bool> isFreeAudienceInDateTime(int AudienceId, DateOnly date, int TimeId);
        Task<bool> isFreeLecturerInDateTime(int LecturerId, DateOnly date, int TimeId);
    }
}
