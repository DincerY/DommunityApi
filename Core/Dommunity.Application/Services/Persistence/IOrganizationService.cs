using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dommunity.Domain.Entities;

namespace Dommunity.Application.Services.Persistence;

public interface IOrganizationService
{
    Task<Organization> GetOrganizationByIdAsync(int id);
    Task<bool> CreateOrganizationAsync(Organization organization);
}