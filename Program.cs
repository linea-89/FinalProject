using FinalProject.Data;
using FinalProject.FloorComponent.Services;
using FinalProject.InventoryComponent.Services;
using FinalProject.Models.FloorModels;
using FinalProject.Models.InventoryModels;
using FinalProject.Models.MoveModels;
using FinalProject.Models.RoomModels;
using FinalProject.Shared.ModelInterfaces;
using FinalProject.MoveComponent.Services.BusinessMove;
using FinalProject.MoveComponent.Services.PrivateMove;
using FinalProject.Repositories;
using FinalProject.RoomComponent.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using FinalProject.MapperComponent;
using FinalProject.Shared.RepositoryInterfaces;
using FinalProject.Shared.MapperInterfaces;

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

//Services
builder.Services.AddScoped<IPrivateMoveService, PrivateMoveService>();
builder.Services.AddScoped<IBusinessMoveService, BusinessMoveService>();
builder.Services.AddScoped<IMoveRepository, MoveRepository>();
builder.Services.AddScoped<IFloorService, FloorService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();

//Repositories
builder.Services.AddScoped<IMoveRepository, MoveRepository>();
builder.Services.AddScoped<IFloorRepository, FloorRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

//Models
builder.Services.AddScoped<IAddress, Address>();
builder.Services.AddScoped<IFloor, Floor>();
builder.Services.AddScoped<IFloorType, FloorType>();
builder.Services.AddScoped<IInventory, Inventory>();
builder.Services.AddScoped<IInventoryType, InventoryType>();
builder.Services.AddScoped<IWrapping, Wrapping>();
builder.Services.AddScoped<IAmenities, Amenities>();
builder.Services.AddScoped<IMove, Move>();
builder.Services.AddScoped<IRoom, Room>();
builder.Services.AddScoped<IRoomType, RoomType>();

//Mappers
builder.Services.AddTransient<IRoomMapper, RoomMapper>();
builder.Services.AddTransient<IFloorMapper, FloorMapper>();
builder.Services.AddTransient<IMoveMapper, MoveMapper>();
builder.Services.AddTransient<IInventoryMapper, InventoryMapper>();




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
