using Dommunity.Application.Repositories;
using Dommunity.Application.Services.Persistence;
using Dommunity.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Dommunity.Application.Services.Infrastructure;

namespace Dommunity.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{

    private readonly IOrganizationService _organizationService;
    private readonly IUserService _userService;
    private readonly IRabbitMQService _rabbitMQService;
    public UsersController(ConnectionFactory connectionFactory, IOrganizationService organizationService, IUserService userService, IRabbitMQService rabbitMqService)
    {

        _organizationService = organizationService;
        _userService = userService;
        _rabbitMQService = rabbitMqService;

    }
    [HttpPost]
    [Route("register-organization/{userId}/{organizationId}")]
    public async Task<IActionResult> RegisterOrganization(int userId, int organizationId)
    {
        Organization organization = await _organizationService.GetOrganizationByIdAsync(organizationId);
        User user = await _userService.GetUserByIdAsync(userId);
        string queueName = user.Name + user.Surname;
        string exchangeName = organization.Title.Replace(' ', '-');


        _rabbitMQService.ExchangeDeclare(exchangeName);
        _rabbitMQService.QueueDeclare(queueName);
        _rabbitMQService.QueueBind(exchangeName, queueName);


        return Ok("Organizasyona kayıt alındı");
    }


}