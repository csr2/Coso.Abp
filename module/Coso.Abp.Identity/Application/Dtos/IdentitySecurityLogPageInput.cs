using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Coso.Abp.Identity.Application.Dtos
{
    public class IdentitySecurityLogPageInput : PagedAndSortedResultRequestDto
    {
        public   DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }
        public string applicationName { get; set; }
        public string identity { get; set; }
        public string actions { get; set; }
        public Guid? userId { get; set; }
        public string userName { get; set; }
        public string clientId { get; set; }
        public string correlationId { get; set; }
    }
}
