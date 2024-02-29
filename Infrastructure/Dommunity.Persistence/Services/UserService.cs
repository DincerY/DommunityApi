using Dommunity.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dommunity.Application.Services.Persistence;
using Dommunity.Domain.Entities;

namespace Dommunity.Persistence.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        var result = await _userRepository.GetSingleAsync(u => u.Id == id);
        if (result == null)
        {
            throw new ArgumentNullException("Bu kimlikte kullanıcı mevcut değil");
        }

        return result;
    }
}