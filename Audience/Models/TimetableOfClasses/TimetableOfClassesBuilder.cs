using Audience.BLL.DTO;
using Audience.BLL.Interfaces;
using Audience.Models.Lecturer;
using AutoMapper;

namespace Audience.Models.TimetableOfClasses
{
    public class TimetableOfClassesBuilder
    {
        ITimetableOfClasseServices services;

        public TimetableOfClassesBuilder(ITimetableOfClasseServices services)
        {
            this.services = services;
        }
        public async Task<List<TimetableOfClassesResponseModel>> BuildAll()
        {
            IEnumerable<TimetableOfClassesDTO> timetableOfClassesDTO = await services.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TimetableOfClassesDTO, TimetableOfClassesResponseModel>()).CreateMapper();
            var timetableOfClassesResponseModels = mapper.Map<IEnumerable<TimetableOfClassesDTO>, List<TimetableOfClassesResponseModel>>(timetableOfClassesDTO);
            return timetableOfClassesResponseModels;
        }
    }
}
