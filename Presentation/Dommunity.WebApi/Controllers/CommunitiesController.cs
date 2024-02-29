using Dommunity.Application.Services.Persistence;
using Dommunity.Application.ViewModels.Community;
using Dommunity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace Dommunity.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommunitiesController : ControllerBase
{
    private readonly IOrganizationService _organizationService;
    private readonly ICommunityService _communityService;
    private readonly ConnectionFactory _connectionFactory;
    private readonly IConnection connection;
    private readonly IModel channel;

    public CommunitiesController(ConnectionFactory connectionFactory, IOrganizationService organizationService, ICommunityService communityService)
    {
        _connectionFactory = connectionFactory;
        _organizationService = organizationService;
        _communityService = communityService;
        connection = connectionFactory.CreateConnection();
        channel = connection.CreateModel();
    } 

    [HttpPost]
    [Route("add-community")]
    public async Task<IActionResult> CreateCommunity([FromBody] VM_CreateCommunity createCommunity)
    {
        Community community = new Community()
        {
            Name = createCommunity.Name,
            Region = createCommunity.Region,
            WorksCommunity = createCommunity.WorksCommunity
        };
        var result = await _communityService.CreateCommunity(community);
        if (result)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }



    [HttpPost]
    [Route("start/{organizationId}")]
    public async Task<IActionResult> StartOrganization(int organizationId)
    {
        var org = await _organizationService.GetOrganizationByIdAsync(organizationId);
        var exhangeName = org.Title.Replace(' ', '-');

        channel.ExchangeDeclare(exhangeName, ExchangeType.Fanout);

        var message = $"{org.Title} başlıklı {org.OrganizationTime} tarihli organizyon başlamıştır";
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exhangeName,routingKey:string.Empty,body:body);
        return Ok("Organizasyon işlemi başlatıldı");
    }
}