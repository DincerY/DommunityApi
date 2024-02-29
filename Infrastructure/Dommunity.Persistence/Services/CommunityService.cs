using Dommunity.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dommunity.Application.Services.Persistence;
using Dommunity.Domain.Entities;

namespace Dommunity.Persistence.Services;

public class CommunityService : ICommunityService
{
    private readonly ICommunityRepository _communityRepository;

    public CommunityService(ICommunityRepository communityRepository)
    {
        _communityRepository = communityRepository;
    }

    public async Task<bool> CreateCommunity(Community community)
    {
        await _communityRepository.AddAsync(community);
        return await _communityRepository.SaveAsync() == 1 ? true : false;
    }
}