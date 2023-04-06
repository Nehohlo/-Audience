using Audience.DAL.EF;
using Audience.DAL.Entities;
using Audience.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Audience.DAL.Repositories
{
    public class TimetableOfClassesRepository : IRepository<TimetableOfClasses>
    {
        private AudienceDbContext db;

        public TimetableOfClassesRepository(AudienceDbContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(TimetableOfClasses item)
        {
            await db.TimetableOfClasses.AddAsync(item);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var search = await db.TimetableOfClasses.FindAsync(id);
            if (search != null)
            {
                db.TimetableOfClasses.Remove(search);
                return true;
            }
            return false;
        }

        public async Task<TimetableOfClasses> Get(int id)
        {
            var search = await db.TimetableOfClasses.FindAsync(id);
            if (search != null)
            {
                return search;
            }
            return null;
        }

        public async Task<IEnumerable<TimetableOfClasses>> GetAll()
        {
            //return await db.TimetableOfClasses.AsNoTracking().ToListAsync();
            return await db.TimetableOfClasses.AsNoTracking().ToListAsync();
        }


        public async Task<TimetableOfClasses> FirstOrDefaultAsync(TimetableOfClasses model)
        {
            var Item = await db.TimetableOfClasses.FirstOrDefaultAsync(
                x => (x.TimeStart == model.TimeStart
                && x.TimeEnd == model.TimeEnd));
            if (Item != null)
            {
                return Item;
            }
            return null;
        }
    }
}
