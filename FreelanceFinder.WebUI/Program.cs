using FreelanceFinder.Infrastructure;
using FreelanceFinder.Application.Services;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FreelanceFinder.Application.Common;
using FreelanceFinder.Core.Entities;
using FreelanceFinder.Application.Common.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddApplicationDbContext(builder.Configuration);

builder.Services.AddAutoMapper(typeof(OrganizationProfile));

// Add entity services
builder.Services.AddScoped<IEntityService<Employer>, EmployerService>();
builder.Services.AddScoped<IEntityService<Freelancer>, FreelancerService>();
builder.Services.AddScoped<IEntityService<ProjectAdvertisement>, ProjectAdvertisementService>();
builder.Services.AddScoped<IEntityService<Project>, ProjectService>();
builder.Services.AddScoped<IEntityService<RequiredSkill>, RequiredSkillService>();
builder.Services.AddScoped<IEntityService<SkillArea>, SkillAreaService>();
builder.Services.AddScoped<IEntityService<Skill>, SkillService>();
builder.Services.AddScoped<IEntityService<Status>, StatusService>();
builder.Services.AddScoped<IEntityService<Currency>, CurrencyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
