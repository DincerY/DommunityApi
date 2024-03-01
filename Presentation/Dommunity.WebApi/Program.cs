using Dommunity.Application.Repositories;
using Dommunity.Application.Services.Infrastructure;
using Dommunity.Application.Services.Persistence;
using Dommunity.Infrastructure.Services;
using Dommunity.Persistence.Contexts;
using Dommunity.Persistence.Repositories;
using Dommunity.Persistence.Services;
using RabbitMQ.Client;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DommunityDbContext>();

builder.Services.AddSingleton<ConnectionFactory>();

builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<ICommunityService, CommunityService>();
builder.Services.AddSingleton<IRabbitMQService, RabbitMQService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICommunityRepository, CommunityRepository>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();




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
