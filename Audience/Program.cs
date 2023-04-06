using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Audience.DAL.EF;
using Audience.BLL.Interfaces;
using Audience.BLL.Services;
using Audience.DAL.Interfaces;
using Audience.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'AudienceContextConnection' not found.");

builder.Services.AddDbContext<AudienceDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services
    .AddTransient<IUnitOfWork, EFUnitOfWork>()
    .AddTransient<IAudiencesServices, AudiencesServices>()
    .AddTransient<IClassServices, ClassServices>()
    .AddTransient<ILecturerServices, LecturerServices>()
    .AddTransient<ITimetableOfClasseServices, TimetableOfClasseServices>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();;

//app.MapControllers();

// Чтобы с других серверов подключать штуки
app.UseCors(options => options
.AllowAnyOrigin()
.AllowAnyHeader()
.AllowAnyMethod());

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
