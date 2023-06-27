using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using UserWebAPI.Authorization;
using UserWebAPI.Data.Context;
using UserWebAPI.Models;
using UserWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Connection with DB
builder.Services.AddDbContext<UserDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("UserConnection")));

builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();

// Add AutoMap extension
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TokenService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Estamos definindo qual a informação da API que estamos documentando
// Qual arquivo XML estamos utilizando
// Permite a execução de comentários XML
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserAPI", Version = "v1" });
//    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
//    c.IncludeXmlComments(xmlPath);
//});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IdadeMinima", policy =>
         policy.AddRequirements(new MinimumAge(18))
    );
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
