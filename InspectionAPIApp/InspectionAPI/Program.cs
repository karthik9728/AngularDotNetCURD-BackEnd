using InspectionAPI.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using InspectionAPI.Mapping;
using InspectionAPI.Model;
using InspectionAPI.Repository.IRepository;
using InspectionAPI.Repository;
using System.Reflection;

var myAllowSpeificOrigins = "_myAllowSpeificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


#region Swagger Documentations

builder.Services.AddSwaggerGen(options =>
{
    var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";   
    var xmlCommentFullPath = Path.Combine(AppContext.BaseDirectory ,xmlCommentFile);
    options.IncludeXmlComments(xmlCommentFullPath);
});

#endregion


#region CORS Policy

builder.Services.AddCors(oprtions =>
{
    oprtions.AddPolicy(name: myAllowSpeificOrigins,
        builder =>
        {
            //builder.WithOrigins("http://locahost:4200").AllowAnyMethod().AllowAnyMethod();
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod();
        });
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

app.UseCors(myAllowSpeificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
