using KnjiznicaApp.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddControllersWithViews().AddJsonOptions( options => options.JsonSerializerOptions = ReferenceLoopHandling.Ignore);

//dodavanje baze podataka
builder.Services.AddDbContext<KnjiznicaContext>(o =>
o.UseSqlServer(
    builder.Configuration.
    GetConnectionString(name: "KnjiznicaContext")
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(opcije =>
    {
        opcije.SerializeAsV2 = true;

    });
    app.UseSwaggerUI(opcije =>
    {
        opcije.ConfigObject.
        AdditionalItems.Add("requestSnippetsEnabled", true);
    });


    app.UseHttpsRedirection();



    app.MapControllers();

    app.Run();
}
