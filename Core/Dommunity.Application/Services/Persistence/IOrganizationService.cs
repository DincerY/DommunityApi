using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dommunity.Application.DTOs;
using Dommunity.Domain.Entities;

namespace Dommunity.Application.Services.Persistence;

public interface IOrganizationService
{
    Task<List<GetOrganizationDto>> GetCommunityOrganizationsAsync(int communityId);
    Task<List<Organization>> GetAll();
    Task<Organization> GetOrganizationByIdAsync(int id);
    Task<bool> CreateOrganizationAsync(Organization organization);
}