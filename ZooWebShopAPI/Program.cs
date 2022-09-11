using FluentEmail.MailKitSmtp;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ZooWebShopAPI;
using ZooWebShopAPI.DataAccess.CommandDataAccess;
using ZooWebShopAPI.DataAccess.QueryDataAccess;
using ZooWebShopAPI.Dtos;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Middleware;
using ZooWebShopAPI.Persistence.DbContexts;
using ZooWebShopAPI.Persistence.Seeders;
using ZooWebShopAPI.Validators;

var builder = WebApplication.CreateBuilder(args);


var emailConfiguration = new EmailConfigurationDto()
{
    EmailFrom = builder.Configuration.GetSection("GmailEmailService")["From"],
    EmailSender = builder.Configuration.GetSection("GmailEmailService")["EmailAddress"],
    EmailPassword = builder.Configuration.GetSection("GmailEmailService")["Password"],
    EmailPort = int.Parse(builder.Configuration.GetSection("GmailEmailService")["Port"]),
    EmailServer = builder.Configuration.GetSection("GmailEmailService")["Server"],
};

var authenticationSettings = new AuthenticationSettings();
builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
    };
});
builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CommandDbContext>();
builder.Services.AddDbContext<QueryDbContext>();
builder.Services.AddScoped<ICommandDataAccess, CommandDataAccess>();
builder.Services.AddScoped<IQueryDataAccess, QueryDataAccess>();
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddScoped<DbSeeder>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ExceptionHandler>();
builder.Services.AddScoped<IValidator<AddCategoryByNameDto>, AddCategoryByNameValidator>();
builder.Services.AddScoped<IValidator<EditProductDto>, EditProductValidator>();
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.AddFluentEmail(emailConfiguration.EmailSender, emailConfiguration.EmailFrom)
    .AddRazorRenderer()
    .AddMailKitSender(new SmtpClientOptions
    {
        Server = emailConfiguration.EmailServer,
        Port = emailConfiguration.EmailPort,
        UseSsl = true,
        RequiresAuthentication = true,
        User = emailConfiguration.EmailSender,
        Password = emailConfiguration.EmailPassword
    });


var app = builder.Build();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(z =>
    {
        z.InjectStylesheet("/SwaggerDarkUI/darkui.css");
    });
}

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
await seeder.SeedData();
app.UseMiddleware<ExceptionHandler>();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();
app.UseAuthorization();

app.MapControllers();

app.Run();
