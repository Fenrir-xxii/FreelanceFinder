using FreelanceFinder.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using FreelanceFinder.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);

var app = builder.Build();

//string? connectionString = builder.Configuration.GetConnectionString("sqlServer");
//string? connectionString2 = builder.Configuration.GetRequiredSection("providerName").Value;
//Console.WriteLine("Connections string");
//Console.WriteLine(connectionString);
//Console.WriteLine("----------");


app.MapGet("/", () => "Hello World!");

app.Run();


