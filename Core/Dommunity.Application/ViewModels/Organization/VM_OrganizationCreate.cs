using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dommunity.Application.ViewModels.Organization;

public class VM_OrganizationCreate
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int CommunityId { get; set; }
}