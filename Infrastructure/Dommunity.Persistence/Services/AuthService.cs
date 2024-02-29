using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dommunity.Application.Repositories;
using Dommunity.Application.Services.Persistence;
using Dommunity.Domain.Entities;

namespace Dommunity.Persistence.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> LoginAsync(string usernameOrEmail, string password)
    {
        var user = await _userRepository.GetSingleAsync(u => u.Email == usernameOrEmail);
        if (user == null)
        {
            user = await _userRepository.GetSingleAsync(u => u.Name == usernameOrEmail);
        }

        if (user == null)
        {
            throw new ArgumentNullException("Email kullanıcı adı hatalı");
        }

        return user.Password == password;
    }

    public async Task<bool> RegisterAsync(User user)
    {
        await _userRepository.AddAsync(user);
        return await _userRepository.SaveAsync() == 1 ? true : false;
    }

   
}