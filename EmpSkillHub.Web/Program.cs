using EmpSkillHub.Data;
using EmpSkillHub.Service.Interfaces;
using EmpSkillHub.Service.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log_.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

string connectionStringName = builder.Configuration.GetValue<string>("AppSettings:UseConnection");

//services to the container.
builder.Services.AddDbContext<EmpSkillHubDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(connectionStringName)));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IEmpSkillRepository, EmpSkillRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IEmpSkillService, EmpSkillService>();


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
