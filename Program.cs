using FinalProject.Data;
using FinalProject.Repositories.Moves;
using FinalProject.Services.BusinessMove;
using FinalProject.Services.Floor;
using FinalProject.Services.Move;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


//Db Context
builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FinalProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FinalProjectContext") ?? throw new InvalidOperationException("Connection string 'FinalProjectContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                options.JsonSerializerOptions.WriteIndented = true;
            });

builder.Services.AddScoped<IPrivateMoveService, PrivateMoveService>();
builder.Services.AddScoped<IBusinessMoveService, BusinessMoveService>();
builder.Services.AddScoped<IFloorService, FloorService>();

//builder.Services.AddScoped<IMoveRepository, MoveRepository>();


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
