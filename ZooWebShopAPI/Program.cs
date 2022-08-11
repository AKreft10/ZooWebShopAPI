using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Middleware;
using ZooWebShopAPI.Persistence.DbContexts;
using ZooWebShopAPI.Persistence.Seeders;
using ZooWebShopAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IDataAccess, DataAccess>();
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddScoped<DbSeeder>();
builder.Services.AddScoped<ExceptionHandler>();
builder.Services.AddScoped<IValidator<AddCategoryByNameDto>, AddCategoryByNameValidator>();
builder.Services.AddScoped<IValidator<EditProductDto>, EditProductValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
await seeder.SeedData();
app.UseMiddleware<ExceptionHandler>();
app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();
app.UseAuthorization();

app.MapControllers();

app.Run();
