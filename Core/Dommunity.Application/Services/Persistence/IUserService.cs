using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dommunity.Domain.Entities;

namespace Dommunity.Application.Services.Persistence;

public interface IUserService
{
    Task<User> GetUserByIdAsync(int id);


}