using Dommunity.Application.Services.Persistence;
using Dommunity.Application.ViewModels.Organization;
using Dommunity.Domain.Entities;
using Dommunity.Persistence.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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