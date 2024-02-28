using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dommunity.Domain.Entities.Base;

namespace Dommunity.Domain.Entities;

public class Community : BaseEntity
{

    public ICollection<Organization> Organizations { get; set; }

}