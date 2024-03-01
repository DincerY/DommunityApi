using Dommunity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dommunity.Application.DTOs
{
    public class GetOrganizationDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime OrganizationTime { get; set; }
    }
}



