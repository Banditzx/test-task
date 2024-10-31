using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Net;
using System.Text;
using TestTask.Infrastructure.Config;
using TestTask.Infrastructure.Interfaces.Repositories;
using TestTask.Infrastructure.Interfaces.Services;
using TestTask.Repositories;
using TestTask.Repositories.Repositories;
using TestTask.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
       builder =>
       {
           builder.WithOrigins("http://localhost:4200",
                               "https://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
       });
});

builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
    options.HttpsPort = 5001; // 443;
});

builder.Services.Configure<AppConfiguration>(builder.Configuration.GetSection("Configuration"));
builder.Services.AddDbContext<StoreEntities>(options => {
    var connection = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connection, sqlOptions =>
    {
        sqlOptions.MigrationsAssembly("TestTask.Api");
    });
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSignalR(c => {
    c.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
    c.KeepAliveInterval = TimeSpan.FromSeconds(10);
    c.EnableDetailedErrors = true;
});

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/test-task-log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Configuration
builder.Services.AddScoped<IConfigurationService, ConfigurationService>();

// Repositories
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<ILocationRepository, LocationRepository>();

// Services
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IConfigurationService, ConfigurationService>();
builder.Services.AddTransient<ILocationService, LocationService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

/******************************Swagger AUTH********************************/
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "TestTaskServer",
        ValidAudience = "TestTaskClient",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("bc8498162dcff2454b7d28eac6318686b8dee7083735ce819c11369c1ebbfa68")),
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test Task", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
/****************************Swagger END*********************************/


var app = builder.Build();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || !app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Task V1");
    });
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<StoreEntities>();
    dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    dbContext.Database.Migrate();
}

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
