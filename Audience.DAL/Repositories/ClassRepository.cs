using Audience.DAL.EF;
using Audience.DAL.Entities;
using Audience.DAL.Interfaces;
using Audience.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Audience.DAL.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private AudienceDbContext db;

        public ClassRepository(AudienceDbContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(Class item)
        {
            await db.Class.AddAsync(item);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var Class = await db.Class.FindAsync(id);
            if (Class != null)
            {
                db.Class.Remove(Class);
                return true;
            }
            return false;
        }

        public async Task<Class> Get(int id)
        {
            var Class = await db.Class.FindAsync(id);
            if (Class != null)
            {
                return Class;
            }
            return null;
        }

        public async Task<IEnumerable<Class>> GetAll()
        {
            var f = await db.Class
                .Include(p => p.timetableOfClasses)
                .Include(c=> c.Audiences)
                .Include(c=> c.Lecturer)
                .ToListAsync();
            return f;
            //return await db.Class.AsNoTracking().ToListAsync();
        }

        public async Task<Class> FirstOrDefaultAsync(Class model)
        {
            var Item = await db.Class.FirstOrDefaultAsync(
                x => (x.AudiencesId == model.AudiencesId
                && x.LecturerId == model.LecturerId));
            if (Item != null)
            {
                return Item;
            }
            return null;
        }

        public async Task<IEnumerable<Class>> GetDate(DateOnly date)
        {
            var get = await db.Class
                .Include(p => p.timetableOfClasses)
                .Include(c => c.Audiences)
                .Include(c => c.Lecturer)
                .Where(d=> d.Date == date)
                .OrderBy(o=>o.timetableOfClasses.Id)
                .ToListAsync();
            return get;
        }

        public async Task<bool> isFreeAudienceInDateTime(int AudienceId, DateOnly date, int TimeId)
        {
            var get = await db.Class
                .FirstOrDefaultAsync(x =>
                (x.AudiencesId == AudienceId &&
                x.Date == date &&
                x.timetableOfClassesId == TimeId));
            if(get==null)
            { 
                return true; 
            }
            return false;
        }

        public async Task<bool> isFreeLecturerInDateTime(int LecturerId, DateOnly date, int TimeId)
        {
            var get = await db.Class
                .FirstOrDefaultAsync(x =>
                (x.LecturerId == LecturerId &&
                x.Date == date &&
                x.timetableOfClassesId == TimeId));
            if (get == null)
            {
                return true;
            }
            return false;
        }
    }
}
