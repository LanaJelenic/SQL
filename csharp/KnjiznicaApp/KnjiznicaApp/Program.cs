using KnjiznicaApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(sgo => { 
    var o = new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Knjiznica API",
        Version = "v1",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
        {
            Email = "lana.jelenic@gmail.com",
            Name = "Lana Jelenic"
        },
        Description = "Ovo je dokumentacija za Knjiznica API",
        License = new Microsoft.OpenApi.Models.OpenApiLicense()
        {
            Name = "Edukacijska licenca"
        }
    };
    sgo.SwaggerDoc("v1", o);
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    sgo.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

});
builder.Services.AddCors(opcije =>
{
    opcije.AddPolicy("CorsPolicy",
        builder =>
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


// dodavanje baze podataka
builder.Services.AddDbContext<KnjiznicaContext>(o =>
    o.UseSqlServer(
        builder.Configuration.
        GetConnectionString(name: "KnjiznicaContext")
        )
    );



var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger(opcije =>
    {
        opcije.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(opcije =>
    {
        opcije.ConfigObject.
        AdditionalItems.Add("requestSnippetsEnabled", true);
    });
//}

app.UseHttpsRedirection();
app.MapControllers();
app.UseStaticFiles();
app.UseCors("CorsPolicy");
app.UseDefaultFiles();
app.UseDeveloperExceptionPage();
app.MapFallbackToFile("index.html");

app.Run();