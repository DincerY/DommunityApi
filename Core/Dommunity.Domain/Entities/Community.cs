﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dommunity.Domain.Entities.Base;

namespace Dommunity.Domain.Entities;

public class Community : BaseEntity
{
    public string Name { get; set; }
    public string WorksCommunity { get; set; }
    public string Region { get; set; }
    public ICollection<Organization> Organizations { get; set; }

}