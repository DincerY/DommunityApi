using Dommunity.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Dommunity.Persistence.Contexts;

public class DommunityDbContext : IdentityDbContext<AppUser, AppRole, string>
{
}