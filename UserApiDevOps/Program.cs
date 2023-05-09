

using APIUserDevOps.Helpers;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.OpenApi.Models;
using System.Data;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// - DAL
builder.Services.AddTransient<IDbConnection, SqlConnection>((service) =>
{
    string connectionString = builder.Configuration.GetConnectionString("Default");
    return new SqlConnection(connectionString);
});
builder.Services.AddScoped<IUserRepository, UserRepository>();
// - BLL
builder.Services.AddScoped<IUserService, UserService>();
// - API Helper
builder.Services.AddSingleton<JwtHelper>();

// Ajout des controllers de l'API
builder.Services.AddControllers();

// La doc Swagger
// - Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Ajout de la doc pour swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "UserApi DevOps",
        Description = "Exemple d'API pour les DevOps de Techni",
    });

    // Ajout de l'authentification dans swagger
    // - Bouton pour se connecter sur l'interface
    options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Entrer votre JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    // - Lock sur les routes (Toutes les routes...)
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Name = "Bearer",
                In = ParameterLocation.Header,
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

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
