using ApiMySQL.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// appsettings.json から接続文字列を取得する
builder.Services.AddDbContext<wpdbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ApplicationDbContext"), 
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.1.38-mariadb")));

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

/*
 * dotnet ef dbcontext scaffold "server=localhost;user id=wpuser;database=wpdb;password=wppass" Pomelo.EntityFrameworkCore.MySql -o Models --force --data-annotations
 */