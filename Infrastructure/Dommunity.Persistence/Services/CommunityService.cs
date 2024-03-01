using Dommunity.Application.Repositories;
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


    public async Task<Community> GetCommunityByIdAsync(int id)
    {
        if (id < 0)
        {
            throw new Exception("Id değeri 0 dan küçük olamaz");
        }
        var result = await _communityRepository.GetSingleAsync(c => c.Id == id);
        if (result == null)
        {
            throw new ArgumentNullException("Bu kimlik değerinde bir topluluk bulunamadı");
        }
        return result;
    }

    public async Task<bool> CreateCommunity(Community community)
    {
        await _communityRepository.AddAsync(community);
        return await _communityRepository.SaveAsync() == 1 ? true : false;
    }
}