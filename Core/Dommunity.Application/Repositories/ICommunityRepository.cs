using Dommunity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dommunity.Application.Repositories;

public interface ICommunityRepository : IBaseRepository<Community>
{
  
}