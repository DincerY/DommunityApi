using Dommunity.Domain.Entities.Base;

namespace Dommunity.Domain.Entities;

public class Organization : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int CommunityId { get; set; }
    public Community Community { get; set; }
    public DateTime OrganizationTime { get; set; }
}