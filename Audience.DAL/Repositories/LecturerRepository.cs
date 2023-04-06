using Audience.DAL.EF;
using Audience.DAL.Entities;
using Audience.DAL.Interfaces;
using Audience.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audience.DAL.Repositories
{
    public class LecturerRepository : ILecturerRepository
    {
        private AudienceDbContext db;

        public LecturerRepository(AudienceDbContext context)
        {
            this.db = context;
        }

        public async Task<bool> Create(Lecturer item)
        {
            await db.Lecturers.AddAsync(item);
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var Lecture = await db.Lecturers.FindAsync(id);
            if (Lecture != null)
            {
                db.Lecturers.Remove(Lecture);
                return true;
            }
            return false;
        }

        public async Task<Lecturer> Get(int id)
        {
            var Lecture = await db.Lecturers.FindAsync(id);
            if (Lecture != null)
            {
                return Lecture;
            }
            return null;
        }

        public async Task<IEnumerable<Lecturer>> GetAll()
        {
            return await db.Lecturers.AsNoTracking().ToListAsync();
        }


        public async Task<Lecturer> FirstOrDefaultAsync(Lecturer model)
        {
            var Item = await db.Lecturers.FirstOrDefaultAsync(
                x=>(x.SurName==model.SurName 
                && x.Name==model.Name
                && x.SurName==model.SurName));
            if (Item != null)
            {
                return Item;
            }
            return null;
        }
    }
}
