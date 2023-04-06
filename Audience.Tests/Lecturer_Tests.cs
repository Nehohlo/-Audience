using Audience.BLL.DTO;
using Audience.BLL.Interfaces;
using Audience.BLL.Services;
using Audience.Controllers;
using Audience.DAL.Interfaces;
using Audience.DAL.Repositories;
using Audience.Tests.Fixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Policy;
using Xunit;

namespace Lecturer_Tests.Tests
{
    public class Lecturer_Tests : IClassFixture<TestDatabaseFixture>
    {

        LecturerController _systemUnderTest;
        ILecturerServices IServices;
        IUnitOfWork unitOfwork;

        public Lecturer_Tests()
        {
            unitOfwork = new EFUnitOfWork(TestDatabaseFixture.db);
            IServices = new LecturerServices(unitOfwork);
            _systemUnderTest = new LecturerController(IServices);
        }

        [Fact]
        public async Task AddNewLecturer_Success()
        {
            LecturerDTO NewElem = new LecturerDTO
            {
                SurName = "Тест Фамилии",
                Name = "Тест Имени",
                Patronymic = "Тест Отчества"
            };

            var result = await IServices.Create(NewElem);

            Xunit.Assert.Equivalent(true, result.Success);
        }

        [Fact]
        public async Task AddNewLecturer_Failed_EntryAlreadyExists()
        {
            LecturerDTO NewElem = new LecturerDTO
            {
                SurName = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович"
            };

            var result = await IServices.Create(NewElem);

            Xunit.Assert.Equivalent(false, result.Success);
        }

        [Fact]
        public async Task DeleteLecturer_Success()
        {
                var result = await IServices.Delete(2);
                Xunit.Assert.Equivalent(true, result.Success);
        }

        [Fact]
        public async Task DeleteLecturer_Failed_NotFound()
        {
                var result = await IServices.Delete(999990000);
                Xunit.Assert.Equivalent(false, result.Success);
        }
    }
}
