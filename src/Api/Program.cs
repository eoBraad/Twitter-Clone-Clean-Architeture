using Infrastructure.database.context;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using Api.Config;
using Api.Filter;
using Application.Services.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Global Validation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation();
    
builder.Services.AddControllers();


// Database Configuration
var conString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<TwitterCloneContext>(options => options.UseMySql(conString, ServerVersion.AutoDetect(conString)));

// Services Configuration
builder.Services.ConfigureRepositories();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

// App Configuration
builder.Services.AddMvc(opt => opt.Filters.Add<ExceptionFilter>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();