using Dommunity.Application.Repositories;
using Dommunity.Application.Services.Persistence;
using Dommunity.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Dommunity.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ConnectionFactory _connectionFactory;
    private readonly IConnection connection;
    private readonly IModel channel;
    private readonly IOrganizationService _organizationService;
    private readonly IUserService _userService;
    public UsersController(ConnectionFactory connectionFactory, IOrganizationService organizationService, IUserService userService)
    {
        _connectionFactory = connectionFactory;
        _organizationService = organizationService;
        _userService = userService;
        connection = connectionFactory.CreateConnection();
        channel = connection.CreateModel();
    }
    [HttpPost]
    [Route("register-organization/{userId}/{organizationId}")]
    public async Task<IActionResult> RegisterOrganization(int userId, int organizationId)
    {
        Organization organization = await _organizationService.GetOrganizationByIdAsync(organizationId);
        User user = await _userService.GetUserByIdAsync(userId);
        string queueName = user.Name + user.Surname;
        string exchangeName = organization.Title.Replace(' ', '-');

        channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout);

        channel.QueueDeclare(queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        channel.QueueBind(queueName,exchangeName,string.Empty);
        
        return Ok("Organizasyona kayıt alındı");
    }


}