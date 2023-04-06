using Audience.DAL.EF;
using Audience.DAL.Entities;
using Audience.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audience.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private AudienceDbContext db;

        public EFUnitOfWork(AudienceDbContext db)
        {
            this.db = db;
        }

        private ClassRepository classRepository;
        private AudiencesRepository audiencesRepository;
        private LecturerRepository lecturerRepository;
        private TimetableOfClassesRepository timetableOfClassesRepository;
        public IAudienceRepository Audiences
        {
            get
            {
                if (audiencesRepository == null)
                    audiencesRepository = new AudiencesRepository(db);
                return audiencesRepository;
            }
        }

        public IClassRepository Class
        {
            get
            {
                if (classRepository == null)
                    classRepository = new ClassRepository(db);
                return classRepository;
            }
        }

        public ILecturerRepository Lecturer
        {
            get
            {
                if (lecturerRepository == null)
                    lecturerRepository = new LecturerRepository(db);
                return lecturerRepository;
            }
        }

        public IRepository<TimetableOfClasses> TimetableOfClasses 
        {
            get
            {
                if (timetableOfClassesRepository == null)
                    timetableOfClassesRepository = new TimetableOfClassesRepository(db);
                return timetableOfClassesRepository;
            }
        }


        public void Save()
        {
               db.SaveChanges();
        }
    }
}
