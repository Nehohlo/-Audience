using Audience.BLL.DTO;
using Audience.BLL.Interfaces;
using Audience.BLL.Services;
using Audience.Controllers;
using Audience.DAL.Interfaces;
using Audience.DAL.Repositories;
using Audience.Models.Audiences;
using Audience.Tests.Fixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Protocol;
using System.Security.Policy;
using Xunit;

namespace Audience.Tests
{
    public class Audiences_Tests : IClassFixture<TestDatabaseFixture>
    {

        AudiencesController _systemUnderTest;
        IAudiencesServices IaudiencesServices;
        IUnitOfWork unitOfwork;
        private static readonly object _lock = new();

        public Audiences_Tests()
        {
            unitOfwork = new EFUnitOfWork(TestDatabaseFixture.db);
            IaudiencesServices = new AudiencesServices(unitOfwork);
            _systemUnderTest = new AudiencesController(IaudiencesServices);
        }

        [Fact]
        public async Task Cont_AddNewAudiences_Failed_NotElem()
        {
            AudiencesAddRequestModel NewAudience = new AudiencesAddRequestModel
            {
                IsHaveMedia = false,
            };

            var result = await _systemUnderTest.Add(NewAudience);

            JsonResult res = new JsonResult(result);

            Xunit.Assert.Equivalent("{\"StatusCode\":400}", result.ToJson());
        }

        [Fact]
        public async Task AddNewAudiences_Success()
        {
            AudiencesDTO NewAudience = new AudiencesDTO
            {
                Number = "8-101",
                IsHaveMedia = false,
            };

            var result = await IaudiencesServices.Create(NewAudience);

            Xunit.Assert.Equivalent(true, result.Success);
        }

        [Fact]
        public async Task AddNewAudiences_Failed_EntryAlreadyExists()
        {
            AudiencesDTO NewAudience = new AudiencesDTO
            {
                Id = 2,
                Number = "8-100",
                IsHaveMedia = false,
            };

            var result = await IaudiencesServices.Create(NewAudience);
            Xunit.Assert.Equivalent(false, result.Success);
        }

        [Fact]
        public async Task DeleteAudinces_Success()
        {
                var result = await IaudiencesServices.Delete(2);
                Xunit.Assert.Equivalent(true, result.Success);
        }

        [Fact]
        public async Task DeleteAudinces_Failed_NotFound()
        {
            var result = await IaudiencesServices.Delete(999990000);
            Xunit.Assert.Equivalent(false, result.Success);
        }
    }
}
