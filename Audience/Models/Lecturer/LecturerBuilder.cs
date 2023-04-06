using Audience.BLL.DTO;
using Audience.BLL.Interfaces;
using Audience.Models.Class;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Audience.Models.Lecturer
{
    public class LecturerBuilder
    {
        ILecturerServices services;

        public LecturerBuilder(ILecturerServices services)
        {
            this.services = services;
        }
        public async Task<List<LecturerResponseModel>> BuildAll()
        {
            IEnumerable<LecturerDTO> lecturerDTO = await services.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<LecturerDTO, LecturerResponseModel>()).CreateMapper();
            var lecturerResponseModels = mapper.Map<IEnumerable<LecturerDTO>, List<LecturerResponseModel>>(lecturerDTO);
            return lecturerResponseModels;
        }

        public async Task<LecturerDTO> BuildAdd(LecturerAddRequestModel model)
        {
            if (model != null)
            {
                return new LecturerDTO
                {
                    SurName=model.SurName,
                    Name=model.Name,
                    Patronymic=model.Patronymic,
                };
            }
            return null;
        }
    }
}
