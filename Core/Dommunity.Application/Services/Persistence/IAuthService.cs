using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dommunity.Domain.Entities;

namespace Dommunity.Application.Services.Persistence;

public interface IAuthService
{
    Task<bool> LoginAsync(string usernameOrEmail, string password);

    Task<bool> RegisterAsync(User user);

}