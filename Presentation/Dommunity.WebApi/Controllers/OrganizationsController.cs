using Dommunity.Application.DTOs;
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
    [Route("get-community-organizations")]
    public async Task<List<GetOrganizationDto>> GetCommunityOrganizations(int communityId)
    {
        var result = await _organizationService.GetCommunityOrganizationsAsync(communityId);
        return result;
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