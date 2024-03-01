using Dommunity.Application.Services.Persistence;
using Dommunity.Application.ViewModels.Organization;
using Dommunity.Domain.Entities;
using Dommunity.Persistence.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dommunity.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrganizationsController : ControllerBase
{
    private readonly IOrganizationService _organizationService;

    public OrganizationsController(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    

    [HttpGet]
    [Route("get-all-organization")]
    public async Task<IActionResult> GetCommunityOrganizations(int communityId)
    {
        return Ok();
    }

    [HttpPost]
    [Route("add-organization")]
    public async Task<IActionResult> AddOrganization([FromBody] VM_OrganizationCreate organizationCreate)
    {
        Organization organization = new Organization()
        {
            Title = organizationCreate.Title,
            Content = organizationCreate.Content,
            OrganizationTime = DateTime.UtcNow,
            CommunityId = organizationCreate.CommunityId,
        };
        var result = await _organizationService.CreateOrganizationAsync(organization);
        return result == true ? Ok() : BadRequest();
    }
}