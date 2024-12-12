
using lesson2;
using MyModelsLib;
using MyModelsLib.Interface;
using MyServiceLib;
using MyFileServiceLib;
using MyFileServiceLib.Interface;
using lesson2.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPizzaService, PizzaService>();
builder.Services.AddSingleton<IWorkerService, WorkerService>();
builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddSingleton<IFileService<MyPizza>>(new ReadWrite<MyPizza>(@"H:\webapi\lesson7\WebApi\lesson2\pizzacollections.json"));
builder.Services.AddSingleton<IFileService<string>>(new ReadWrite<string>(@"H:\webapi\lesson7\WebApi\lesson2\actionLog.txt"));

builder.Services.AddProblemDetails();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseractionLog();

app.Run();
