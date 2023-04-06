using Audience.BLL.DTO;
using Audience.BLL.Interfaces;
using Audience.DAL.Entities;
using Audience.DAL.Interfaces;
using Audience.Infrastructure.Services;
using AutoMapper;

namespace Audience.BLL.Services
{
    public class TimetableOfClasseServices : ITimetableOfClasseServices
    {
        IUnitOfWork Database { get; set; }

        public TimetableOfClasseServices(IUnitOfWork database)
        {
            Database = database;
        }

        public async Task<TimetableOfClassesDTO> Get(int id)
        {
            var get = await Database.TimetableOfClasses.Get(id);
            if (get != null)
            {
                TimetableOfClassesDTO timetableOfClassesDTO = new TimetableOfClassesDTO
                {
                    Id = id,
                    TimeStart = get.TimeStart,
                    TimeEnd= get.TimeEnd,

                };
                return timetableOfClassesDTO;
            }
            return null;
        }

        public async Task<IEnumerable<TimetableOfClassesDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TimetableOfClasses, TimetableOfClassesDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<TimetableOfClasses>, List<TimetableOfClassesDTO>>(await Database.TimetableOfClasses.GetAll());
        }
    }
}
