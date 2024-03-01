using Core.CrossCuttingConcerns.Exceptions;
using Dommunity.Application.DTOs;
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


    public async Task<List<GetOrganizationDto>> GetCommunityOrganizationsAsync(int communityId)
    {
        var result = await _organizationRepository.Table.Where(o => o.CommunityId == communityId).Select(o => new GetOrganizationDto()
        {
            Id = o.Id,
            Content = o.Content,
            OrganizationTime = o.OrganizationTime,
            Title = o.Title
        }).ToListAsync();
        if (result == null || result.Count == 0)
        {
            throw new BusinessException("Topluluk kimliğine ait bir organizasyon bulunmadı");
        }
        return result;
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