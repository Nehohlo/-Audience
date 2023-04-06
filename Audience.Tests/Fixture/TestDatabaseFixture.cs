using Audience.DAL.EF;
using Audience.DAL.Entities;
using Audience.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Audience.Tests.Fixture
{
    public class TestDatabaseFixture
    {
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=AudienceTestsDb;Trusted_Connection=True";
        private static readonly object _lock = new();
        public static AudienceDbContext db;

        public TestDatabaseFixture()
        {
            lock (_lock)
            {
                //using (var context = CreateContext())
                //{
                var context = CreateContext();
                    bool deleted = context.Database.EnsureDeleted();
                    //if (deleted == true)
                    //{
                    context.Database.EnsureCreated();
                    context.SaveChanges();
                    //}
                    //context.Database.ExecuteSqlAsync($"SET IDENTITY_INSERT Lecturers ON;");
                    //context.Database.ExecuteSqlAsync($"SET IDENTITY_INSERT Audiences ON;");
                    context.AddRange(
                        new Lecturer() { SurName = "Иванов", Name = "Иван", Patronymic = "Иванович" },
                        new Lecturer() { SurName = "Иванов", Name = "Николай", Patronymic = "Иванович" },
                        new Lecturer() { SurName = "Павлов", Name = "Иван", Patronymic = "Иванович" },
                        new Lecturer() { SurName = "Павлов", Name = "Иван", Patronymic = "Сергеевич" },
                        new Audiences() { Number = "8-100", IsHaveMedia = false },
                        new Audiences() { Number = "504", IsHaveMedia = false });
                    //context.Database.ExecuteSqlAsync($"SET IDENTITY_INSERT Lecturers OFF;");
                    //context.Database.ExecuteSqlAsync($"SET IDENTITY_INSERT Audiences OFF;");
                    context.SaveChanges();
                    //context.Database.ExecuteSqlAsync($"SET IDENTITY_INSERT Lecturers OFF");
                    //context.Database.ExecuteSqlAsync($"SET IDENTITY_INSERT Audiences OFF");
                    db = context;
                //}
            }
        }

        public AudienceDbContext CreateContext()
            => new AudienceDbContext(
                new DbContextOptionsBuilder<AudienceDbContext>()
                    .UseSqlServer(ConnectionString,o =>
                    {
                        o.EnableRetryOnFailure();
                    })
                    .Options);

        public static AudienceDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AudienceDbContext>()
                .UseSqlServer(ConnectionString)
                .Options;
            var context = new AudienceDbContext(options);
            context.Database.EnsureCreated();
            context.AddRange(
                        new Lecturer() { SurName = "Иванов", Name = "Иван", Patronymic = "Иванович" },
                        new Lecturer() { SurName = "Иванов", Name = "Николай", Patronymic = "Иванович" },
                        new Lecturer() { SurName = "Павлов", Name = "Иван", Patronymic = "Иванович" },
                        new Lecturer() { SurName = "Павлов", Name = "Иван", Patronymic = "Сергеевич" });
            context.SaveChanges();
            return context;
        }

        public static void Dispose(AudienceDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
