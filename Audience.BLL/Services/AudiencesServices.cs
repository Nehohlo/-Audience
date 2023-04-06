using Audience.BLL.DTO;
using Audience.BLL.Interfaces;
using Audience.DAL.Entities;
using Audience.DAL.Interfaces;
using Audience.Infrastructure.Services;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace Audience.BLL.Services
{
    public class AudiencesServices : IAudiencesServices
    {
        IUnitOfWork Database { get; set; }

        public AudiencesServices(IUnitOfWork database)
        {
            Database = database;
        }

        public async Task<Result> Create(AudiencesDTO item)
        {
            if (item == null) return "Ошибка";
            //Проверка наличия такого же кабинета.
            var search = await Database.Audiences.FirstOrDefaultAsync(
                new Audiences
                {
                    Number=item.Number
                });
            if (search != null)
            {
                return "Такая аудитория уже есть";
            }
            Audiences audience = new Audiences
            {
                Id= item.Id,
                Number= item.Number,
                IsHaveMedia = item.IsHaveMedia,
            };
            var create = await Database.Audiences.Create(audience);
            if (create)
            {
                Database.Save();
                return new Result
                {
                    Success = true,
                    Message = "Аудитория добавлена"
                };
            }
            return "Аудитория НЕ добавлена";
        }

        public async Task<Result> Delete(int id)
        {
            var del = await Database.Audiences.Delete(id);
            if (!del)
            {
                return "Ошибка удаления. Такой элемент не найден.";
            }

            return new Result
            {
                Success = true,
                Message = "Элемент удалён"
            };

        }

        public async Task<AudiencesDTO> Get(int id)
        {
            var get = await Database.Audiences.Get(id);
            if (get != null)
            {
                AudiencesDTO audiencesDTO = new AudiencesDTO
                {
                    Id = id,
                    Number = get.Number,
                    IsHaveMedia = get.IsHaveMedia,
                };
                return audiencesDTO;
            }
            return null;
        }

        public async Task<IEnumerable<AudiencesDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Audiences, AudiencesDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Audiences>, List<AudiencesDTO>>(await Database.Audiences.GetAll());
        }
    }
}
