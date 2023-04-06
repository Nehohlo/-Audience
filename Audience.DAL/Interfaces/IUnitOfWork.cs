using Audience.DAL.Entities;
using Audience.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Audience.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAudienceRepository Audiences { get; }
        ILecturerRepository Lecturer { get; }
        IRepository<TimetableOfClasses> TimetableOfClasses { get; }

        IClassRepository Class { get; }
        void Save();
    }
}
