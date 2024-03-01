using Dommunity.Application.Services.Persistence;
using Dommunity.Application.ViewModels.Community;
using Dommunity.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using Dommunity.Application.Services.Infrastructure;
using Newtonsoft.Json;

namespace Dommunity.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommunitiesController : ControllerBase
{
    private readonly IOrganizationService _organizationService;
    private readonly ICommunityService _communityService;
    private readonly IRabbitMQService _rabbitMQService;

    public CommunitiesController(ConnectionFactory connectionFactory, IOrganizationService organizationService, ICommunityService communityService, IRabbitMQService rabbitMqService)
    {
        _organizationService = organizationService;
        _communityService = communityService;
        _rabbitMQService = rabbitMqService;
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


        _rabbitMQService.ExchangeDeclare(exhangeName);


        var message = $"{org.Title} başlıklı {org.OrganizationTime} tarihli organizyon başlamıştır";
        var body = Encoding.UTF8.GetBytes(message);

        _rabbitMQService.BasicPublish(exhangeName,body);

        return Ok("Organizasyon işlemi başlatıldı");
    }
}