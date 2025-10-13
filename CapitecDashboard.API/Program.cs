using CapitecDashboard.API.Utils;
using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Extensions;
using CapitecDashboard.Domain.Interfaces;
using CapitecDashboard.Domain.Interfaces.Repositories;
using CapitecDashboard.Domain.Interfaces.Services.CommandService;
using CapitecDashboard.Domain.Interfaces.Services.QueryService;
using CapitecDashboard.Domain.Services;
using CapitecDashboard.Domain.Services.CommandServices;
using CapitecDashboard.Domain.Services.QueryServices;
using CapitecDashboard.Domain.Utils;
using CapitecDashboard.Infrastructure.DbContexts;
using CapitecDashboard.Infrastructure.Extensions;
using CapitecDashboard.Infrastructure.Repositories.BaseRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var baseConfig = new ConfigurationBuilder()
    .AddCommandLine(args)
    .Build();

var environment = baseConfig.GetValue<string>("environment");
var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .Build();

// Add services to the container.
builder.Services.AddDbContext<InvoiceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddRazorPages();
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<InvoiceDbContext>()
        .AddDefaultTokenProviders();
// Register Generic Repositories
builder.Services.AddTransient(typeof(ICommandRepository<>), typeof(CommandRepository<>));
builder.Services.AddTransient(typeof(IQueryRepository<,>), typeof(QueryRepository<,>));

// Register Command Services
builder.Services.AddTransient<IAccessLevelCommandService, AccessLevelCommandService>();
builder.Services.AddTransient<IInvoiceCommandService, InvoiceCommandService>();

// Register Query Services  
builder.Services.AddTransient<IInvoiceQueryService, InvoiceQueryService>();

// Register Authentication Service
builder.Services.AddTransient<IAuthenticateService, AuthenticateService>();


//builder.Services.AddIdentityCore<User>();
//builder.Services.AddScoped<RoleManager<Role>>();
//Framework
builder.Services.AddDomain();
builder.Services.AddInfrastructure();
builder.Services.AddTransient<IWebSecurity, WebSecurity>();
builder.Services.AddCors();
builder.Services.AddControllers(o =>
{
    o.AllowEmptyInputInBodyModelBinding = true;
}).AddNewtonsoftJson(
             options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize
         );
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


// Configure the HTTP request pipeline.
if (builder.Build().Environment.IsDevelopment())
{
    builder.Build().MapOpenApi();
}

builder.Build().UseHttpsRedirection();

builder.Build().UseAuthorization();
builder.Build().UseRouting();
builder.Build().UseAuthorization();

builder.Build().MapControllers();

builder.Build().Run();
