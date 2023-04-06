using Audience.BLL.DTO;
using Audience.BLL.Interfaces;
using Audience.DAL.Entities;
using Audience.DAL.Interfaces;
using Audience.Infrastructure.Services;
using AutoMapper;
using System.Numerics;

namespace Audience.BLL.Services
{
    public class LecturerServices : ILecturerServices
    {
        IUnitOfWork Database { get; set; }

        public LecturerServices(IUnitOfWork database)
        {
            Database = database;
        }

        public async Task<Result> Create(LecturerDTO item)
        {
            if (item == null) return "Ошибка";

            var search = await Database.Lecturer.FirstOrDefaultAsync(
                new Lecturer
                {
                    SurName=item.SurName,
                    Name = item.Name,
                    Patronymic=item.Patronymic,
                });

            if(search != null)
            {
                return "Такой преподаватель уже есть.";
            }

            Lecturer lecturer = new Lecturer
            {
                SurName = item.SurName,
                Name = item.Name,
                Patronymic = item.Patronymic,
            };
            var create = await Database.Lecturer.Create(lecturer);
            if (create)
            {
                Database.Save();
                return new Result
                {
                    Success = true,
                    Message = "Преподаватель добавлен"
                };
            }
            return "Преподаватель НЕ добавлен";
        }

        public async Task<Result> Delete(int id)
        {
            var del = await Database.Lecturer.Delete(id);
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

        public async Task<LecturerDTO> Get(int id)
        {
            var get = await Database.Lecturer.Get(id);
            if (get != null)
            {
                LecturerDTO lecturerDTO = new LecturerDTO
                {
                    Id = id,
                    SurName = get.SurName,
                    Name = get.Name,
                    Patronymic = get.Patronymic,
                };
                return lecturerDTO;
            }
            return null;
        }

        public async Task<IEnumerable<LecturerDTO>> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Lecturer, LecturerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Lecturer>, List<LecturerDTO>>(await Database.Lecturer.GetAll());
        }
    }
}
