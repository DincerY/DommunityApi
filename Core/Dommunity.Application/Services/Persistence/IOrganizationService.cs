using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dommunity.Domain.Entities;

namespace Dommunity.Application.Services.Persistence;

public interface IOrganizationService
{
    Task<List<Organization>> GetCommunityOrganizationsAsync();
    Task<List<Organization>> GetAll();
    Task<Organization> GetOrganizationByIdAsync(int id);
    Task<bool> CreateOrganizationAsync(Organization organization);
}