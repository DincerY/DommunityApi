using Dommunity.Application.Repositories;
using Dommunity.Application.Services.Persistence;
using Dommunity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dommunity.Persistence.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _organizationRepository;

    public OrganizationService(IOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }


    public Task<List<Organization>> GetCommunityOrganizationsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Organization>> GetAll()
    {
        return await _organizationRepository.GetAll().ToListAsync();
    }

  

    public async Task<Organization> GetOrganizationByIdAsync(int id)
    {
        var org = await _organizationRepository.GetSingleAsync(o => o.Id == id);
        if (org == null)
        {
            throw new ArgumentNullException("Bu kimliğe ait organizyon bulunamadı");
        }
        return org;
    }

    public async Task<bool> CreateOrganizationAsync(Organization organization)
    {
        await _organizationRepository.AddAsync(organization);
        return await _organizationRepository.SaveAsync() == 1 ? true : false;
    }
}