using Coso.Abp.Identity.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Coso.Abp.Identity.Application
{
    public interface IIdentitySecurityLogAppService : IApplicationService
    {
        Task<PagedResultDto<IdentitySecurityLogDto>> GetListAsync(IdentitySecurityLogPageInput input);

        Task<PagedResultDto<IdentitySecurityLogDto>> GetUserListAsync(IdentitySecurityLogPageInput input);
        //Task<long> GetCountAsync(IdentitySecurityLogPageInput input);

    }
}
