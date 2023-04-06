using Audience.BLL.DTO;
using Audience.BLL.Interfaces;
using Audience.Models.Lecturer;
using AutoMapper;

namespace Audience.Models.Audiences
{
    public class AudiencesBuilder
    {
        IAudiencesServices services;

        public AudiencesBuilder(IAudiencesServices services)
        {
            this.services = services;
        }
        public async Task<List<AudiencesResponseModel>> BuildAll()
        {
            IEnumerable<AudiencesDTO> audiencesDTO = await services.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AudiencesDTO, AudiencesResponseModel>()).CreateMapper();
            var audiencesResponseModels = mapper.Map<IEnumerable<AudiencesDTO>, List<AudiencesResponseModel>>(audiencesDTO);
            return audiencesResponseModels;
        }

        public async Task<AudiencesDTO> BuildAdd(AudiencesAddRequestModel model)
        {
            if (model != null)
            {
                return new AudiencesDTO
                {
                    Number = model.Number,
                    IsHaveMedia = model.IsHaveMedia,
                };
            }
            return null;
        }
    }
}
