using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProfOaksKantoPokedex;
using ProfOaksKantoPokedex.DbContexts;
using ProfOaksKantoPokedex.Services;
using Serilog;
using System.Reflection;
using System.Text;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/profoakskantopokedex.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
})
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile) ;

    setupAction.IncludeXmlComments(xmlCommentsFullPath);

    setupAction.AddSecurityDefinition("ProfOaksKantoPokedexBearerAuth", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Input a valid token to access this API"
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ProfOaksKantoPokedexBearerAuth" }
            }, new List<string>() }
    });
}
    );
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
builder.Services.AddSingleton<PokemonDataStore>();

builder.Services.AddDbContext<ProfOaksKantoPokedexContext>(
    dbContextOptions => dbContextOptions.UseSqlite(
        builder.Configuration["ConnectionStrings:ProfOaksDBConnectionString"]));

builder.Services.AddScoped<IProfOaksKantoPokedexRepository, ProfOaksKantoPokedexRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Authentication:Issuer"],
                ValidAudience = builder.Configuration["Authentication:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))

            };

        }

    );

builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    setupAction.ReportApiVersions = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//Adds endpoints for controller actions without specifying routes
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
