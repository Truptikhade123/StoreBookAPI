using DomainLayer.EntityDataMapping;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using RepositoryLayer.Repositories;
using RepositoryLayer.Repository;
using ServiceLayer.CustomServices;
using ServiceLayer.ICustomServices;
var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
// Add services to the container.
//Sql Dependency Injection
var ConnectionString = builder.Configuration.GetConnectionString("BusinessHubConnectionString");
builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
{
    options.UseSqlServer(ConnectionString);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Service Injected
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<ICustomService<Student>, StudentServiceGeneric>();
builder.Services.AddScoped<IStudentService, StudentService>();

//builder.Logging.ClearProviders();
builder.Logging.AddConsole();
//builder.Services.AddLogging(config =>
//{
//    config.Services.AddSingleton<ILoggerFactory>(new LoggerFactory());
//});
#endregion

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();