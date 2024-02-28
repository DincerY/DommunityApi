using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dommunity.Domain.Entities.Base;

namespace Dommunity.Domain.Entities;

public class Organization : BaseEntity
{
    public string CommunityId { get; set; }
    public Community Community { get; set; }
}