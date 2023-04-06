using Audience.BLL.DTO;
using Audience.BLL.Interfaces;
using Audience.DAL.Entities;
using Audience.DAL.Interfaces;
using Audience.Infrastructure.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audience.BLL.Services
{
    public class ClassServices : IClassServices
    {
        IUnitOfWork Database { get; set; }

        public ClassServices(IUnitOfWork database)
        {
            Database = database;
        }
        public async Task<Result> Create(ClassDTO model)
        {
            if (model == null) return "Ошибка";
            //Проверка отсутсвия пары у данного преподавателя

            var checkLec = await Database.Lecturer.Get(model.Lecturer.Id);
            if (checkLec == null)
            {
                return "Такого преподавателя нет";
            }
            var checkAud = await Database.Audiences.Get(model.Audiences.Id);
            if (checkAud == null)
            {
                return "Такой аудитории нет";
            }
            var checkTime = await Database.TimetableOfClasses.Get(model.timetableOfClasses.Id);
            if (checkTime == null)
            {
                return "Такого времени нет";
            }
            bool isFreeLec = await Database.Class.isFreeLecturerInDateTime(
                model.Lecturer.Id,
                model.Date,
                model.timetableOfClasses.Id);
            if (isFreeLec == false)
            {
                return "Данный преподаватель занят в это время";
            }

            bool isFreeAud = await Database.Class.isFreeAudienceInDateTime(
                model.Audiences.Id,
                model.Date,
                model.timetableOfClasses.Id);
            if (isFreeAud == false)
            {
                return "Данная аудитория занята в это время";
            }

            Class NewClass = new Class
            {
                Date= model.Date,
                AudiencesId= model.Audiences.Id,
                LecturerId= model.Lecturer.Id,
                NameGroup= model.NameGroup,
                timetableOfClassesId= model.timetableOfClasses.Id,
                isNeedMedia= model.isNeedMedia,
            };
            var create = await Database.Class.Create(NewClass);
            if (create)
            {
                Database.Save();
                return new Result
                {
                    Success = true,
                    Message = "Пара добавлена"
                };
            }
            return "Пара НЕ добавлена";
        }

        public Task<Result> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ClassDTO> Get(int id)
        {
            var get = await Database.Class.Get(id);

            ClassDTO classDTO = new ClassDTO()
            {
                Id = get.Id,
                Date = get.Date,
                timetableOfClasses = new TimetableOfClassesDTO
                {
                    Id = get.timetableOfClasses.Id,
                    TimeStart = get.timetableOfClasses.TimeStart,
                    TimeEnd = get.timetableOfClasses.TimeEnd,
                },
                isNeedMedia = get.isNeedMedia,
                NameGroup = get.NameGroup,
                Audiences = new AudiencesDTO
                {
                    Id = get.Audiences.Id,
                    Number = get.Audiences.Number,
                    IsHaveMedia = get.Audiences.IsHaveMedia
                },
                Lecturer = new LecturerDTO
                {
                    Id = get.Lecturer.Id,
                    SurName = get.Lecturer.SurName,
                    Name = get.Lecturer.Name,
                    Patronymic = get.Lecturer.Patronymic
                },
            };
            return classDTO;
        }

        public async Task<List<ClassDTO>> GetAll()
        {
            var search=await Database.Class.GetAll();
            List<ClassDTO> all = new List<ClassDTO>();
            foreach(var e in search)
            {
                ClassDTO classDTO = new ClassDTO()
                {
                    Id = e.Id,
                    Date = e.Date,
                    timetableOfClasses = new TimetableOfClassesDTO
                    {
                        Id = e.timetableOfClasses.Id,
                        TimeStart = e.timetableOfClasses.TimeStart,
                        TimeEnd = e.timetableOfClasses.TimeEnd,
                    },
                    isNeedMedia = e.isNeedMedia,
                    NameGroup = e.NameGroup,
                    Audiences = new AudiencesDTO
                    {
                        Id = e.Audiences.Id,
                        Number = e.Audiences.Number,
                        IsHaveMedia = e.Audiences.IsHaveMedia
                    },
                    Lecturer=new LecturerDTO
                    {
                        Id=e.Lecturer.Id,
                        SurName=e.Lecturer.SurName,
                        Name=e.Lecturer.Name,
                        Patronymic = e.Lecturer.Patronymic
                    },
                };
                all.Add(classDTO);
            }
            return all;
           //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Class, ClassDTO>()).CreateMapper();
           //return mapper.Map<IEnumerable<Class>, List<ClassDTO>>(await Database.Class.GetAll());
           //return await Database.Class.GetAll();
        }

        public async Task<List<ClassDTO>> GetDate(DateOnly date)
        {
            var search = await Database.Class.GetDate(date);
            List<ClassDTO> all = new List<ClassDTO>();
            foreach (var e in search)
            {
                ClassDTO classDTO = new ClassDTO()
                {
                    Id = e.Id,
                    Date = e.Date,
                    timetableOfClasses = new TimetableOfClassesDTO
                    {
                        Id = e.timetableOfClasses.Id,
                        TimeStart = e.timetableOfClasses.TimeStart,
                        TimeEnd = e.timetableOfClasses.TimeEnd,
                    },
                    isNeedMedia = e.isNeedMedia,
                    NameGroup = e.NameGroup,
                    Audiences = new AudiencesDTO
                    {
                        Id = e.Audiences.Id,
                        Number = e.Audiences.Number,
                        IsHaveMedia = e.Audiences.IsHaveMedia
                    },
                    Lecturer = new LecturerDTO
                    {
                        Id = e.Lecturer.Id,
                        SurName = e.Lecturer.SurName,
                        Name = e.Lecturer.Name,
                        Patronymic = e.Lecturer.Patronymic
                    },
                };
                all.Add(classDTO);
            }
            return all;
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Class, ClassDTO>()).CreateMapper();
            //return mapper.Map<IEnumerable<Class>, List<ClassDTO>>(await Database.Class.GetAll());
            //return await Database.Class.GetAll();
        }

    }
}
