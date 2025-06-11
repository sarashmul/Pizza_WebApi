
using lesson2;
using MyModelsLib;
using MyModelsLib.Interface;
using MyServiceLib;
using MyFileServiceLib;
using MyFileServiceLib.Interface;
using lesson2.Middlewares;
using lesson2.login;
//using lesson2.login.ILoginService;
using Microsoft.AspNetCore.Authentication.JwtBearer;

//using lesson2.login.ILoginService;
using Microsoft.OpenApi.Models;


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


        // builder.Services.AddSwaggerGen();

        builder.Services
              .AddAuthentication(options =>
              {
                  options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
              })
              .AddJwtBearer(cfg =>
              {
                  cfg.RequireHttpsMetadata = false;
                  cfg.TokenValidationParameters = MyPizzaTokenService.GetTokenValidationParameters();
              });

        builder.Services.AddAuthorization(cfg =>
        {
            cfg.AddPolicy("Admin", policy => policy.RequireClaim("Role", "Admin"));
            cfg.AddPolicy("SuperWorker", policy => policy.RequireClaim("Role", "SuperWorker"));
        });


        
                builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyPyzza", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                { new OpenApiSecurityScheme
                        {
                         Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                    new string[] {}
                }
                        });
        });



// builder.Services.AddProblemDetails();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
}
else
{
    app.UseExceptionHandler("/error");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDefaultFiles();
app.UseStaticFiles();
// app.UseractionLog();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.UseActionLog();

app.Run();

