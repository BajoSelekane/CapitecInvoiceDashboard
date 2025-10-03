using CapitecDashboard.API.Utils;
using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Extensions;
using CapitecDashboard.Domain.Utils;
using CapitecDashboard.Infrastructure.DbContexts;
using CapitecDashboard.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<InvoiceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddRazorPages();
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<InvoiceDbContext>()
        .AddDefaultTokenProviders();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
