using System.Linq.Expressions;
using Dommunity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dommunity.Application.Repositories;

public interface IOrganizationRepository : IBaseRepository<Organization>
{

}