using Inspections.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Data Base Connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Enable Cross Platform CORS Crossplatfrom Resource Sharing
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http//localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
