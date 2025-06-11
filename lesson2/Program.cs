
using lesson2;
using MyModelsLib;
using MyModelsLib.Interface;
using MyServiceLib;
using MyFileServiceLib;
using MyFileServiceLib.Interface;
using lesson2.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var dataPath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPizzaService, PizzaService>();
builder.Services.AddSingleton<IWorkerService, WorkerService>();
builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddSingleton<IFileService<MyPizza>>(
    new ReadWrite<MyPizza>(Path.Combine(dataPath, "pizzacollections.json"))
);
builder.Services.AddSingleton<IFileService<string>>(
    new ReadWrite<string>(Path.Combine(dataPath, "actionLog.txt"))
);

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

app.UseActionLog();

app.Run();
