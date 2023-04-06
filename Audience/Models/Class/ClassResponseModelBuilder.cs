using Audience.BLL.DTO;
using Audience.BLL.Interfaces;
using Audience.Infrastructure.Services;
using Audience.Models.Audiences;
using Audience.Models.Lecturer;
using Audience.Models.TimetableOfClasses;

namespace Audience.Models.Class
{
    public class ClassResponseModelBuilder
    {
        IClassServices services;

        public ClassResponseModelBuilder(IClassServices services)
        {
            this.services = services;
        }
        public async Task<List<ClassResponseModel>> Build()
        {
            List<ClassDTO> all = await services.GetAll();
            List<ClassResponseModel> CRM = new List<ClassResponseModel>();
            foreach (var item in all)
            {
                ClassResponseModel classResponse = new ClassResponseModel
                {
                    Date = item.Date,
                    timetableOfClasses = new TimetableOfClassesResponseModel
                    {
                        Id=item.timetableOfClasses.Id,
                        TimeStart = item.timetableOfClasses.TimeStart,
                        TimeEnd = item.timetableOfClasses.TimeEnd,
                    },
                    isNeedMedia = item.isNeedMedia,
                    NameGroup = item.NameGroup,
                    Audiences = new AudiencesResponseModel
                    {
                        Number = item.Audiences.Number,
                        IsHaveMedia = item.Audiences.IsHaveMedia
                    },
                    Lecturer = new LecturerResponseModel
                    {
                        SurName = item.Lecturer.SurName,
                        Name = item.Lecturer.Name,
                        Patronymic = item.Lecturer.Patronymic
                    },

                };
                CRM.Add(classResponse);
            }
            return CRM;
        }

        public async Task<List<ClassResponseModel>> BuildGetDate(ClassGetDateRequestModel date)
        {
            DateOnly dateOnly= new DateOnly(date.Year,date.Month,date.Day);
            List<ClassDTO> all = await services.GetDate(dateOnly);
            List<ClassResponseModel> CRM = new List<ClassResponseModel>();
            foreach (var item in all)
            {
                ClassResponseModel classResponse = new ClassResponseModel
                {
                    Date = item.Date,
                    timetableOfClasses = new TimetableOfClassesResponseModel
                    {
                        Id = item.timetableOfClasses.Id,
                        TimeStart = item.timetableOfClasses.TimeStart,
                        TimeEnd = item.timetableOfClasses.TimeEnd,
                    },
                    isNeedMedia = item.isNeedMedia,
                    NameGroup = item.NameGroup,
                    Audiences = new AudiencesResponseModel
                    {
                        Number = item.Audiences.Number,
                        IsHaveMedia = item.Audiences.IsHaveMedia
                    },
                    Lecturer = new LecturerResponseModel
                    {
                        SurName = item.Lecturer.SurName,
                        Name = item.Lecturer.Name,
                        Patronymic = item.Lecturer.Patronymic
                    },

                };
                CRM.Add(classResponse);
            }
            return CRM;
        }
    
        public async Task<Result> BuildAdd(ClassAddRequestModel model)
        {
            ClassDTO classDTO = new ClassDTO
            {
                Date = new DateOnly(model.Year, model.Month, model.Day),
                Audiences = new AudiencesDTO
                {
                    Id=model.AudienceId
                },
                Lecturer = new LecturerDTO
                {
                    Id = model.LecturerId,
                },
                NameGroup= model.NameGroup,
                timetableOfClasses = new TimetableOfClassesDTO
                {
                    Id = model.TimetableOfClassesId,
                },
                isNeedMedia = model.isNeedMedia
            };
            return await services.Create(classDTO);
        }
    }
}
