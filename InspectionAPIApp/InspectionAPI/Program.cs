using InspectionAPI.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using InspectionAPI.Mapping;
using InspectionAPI.Model;
using InspectionAPI.Repository.IRepository;
using InspectionAPI.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


#region

builder.Services.AddSwaggerGen(options =>
{
    

    var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";   
    var xmlCommentFullPath = Path.Combine(AppContext.BaseDirectory ,xmlCommentFile);
    options.IncludeXmlComments(xmlCommentFullPath);
});


#endregion

builder.Services.AddAutoMapper(typeof(AutoMapping));

#region Repository Dependecy Injection

builder.Services.AddScoped<IInspectionRepository, InspectionRepository>();

#endregion

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
