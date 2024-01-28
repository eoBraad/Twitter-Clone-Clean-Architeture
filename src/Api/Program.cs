using Infrastructure.database.context;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using Api.Config;
using Application.Services.AutoMapper;
using Api.Filter;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Global Validation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation();

// Database Configuration
var conString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<TwitterCloneContext>(options => options.UseMySql(conString, ServerVersion.AutoDetect(conString)));

// Services Configuration
builder.Services.ConfigureRepositories();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.ConfigureUseCases();

// App Configuration
builder.Services.AddMvc(opt => opt.Filters.Add<ExceptionFilter>());

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.MapControllers();

app.Run();