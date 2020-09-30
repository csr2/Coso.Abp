using Coso.Abp.Identity.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Coso.Abp.Identity.Application
{
    public class IdentitySecurityLogAppService : ApplicationService, IIdentitySecurityLogAppService
    {
        private readonly IIdentitySecurityLogRepository _identitySecurityLogRepository;

        public IdentitySecurityLogAppService(IIdentitySecurityLogRepository identitySecurityLogRepository)
        {
            _identitySecurityLogRepository = identitySecurityLogRepository;
        }

        public async Task<PagedResultDto<IdentitySecurityLogDto>> GetListAsync(IdentitySecurityLogPageInput input)
        {
            var count = (long)await _identitySecurityLogRepository.GetCountAsync(input.startTime, input.endTime,
                 input.applicationName, input.identity, input.actions, input.userId,
                 input.userName, input.clientId, input.correlationId);

            var list = await _identitySecurityLogRepository.GetListAsync(input.Sorting, input.MaxResultCount,
                input.SkipCount, input.startTime, input.endTime,
                 input.applicationName, input.identity, input.actions, input.userId,
                 input.userName, input.clientId, input.correlationId);

            return new PagedResultDto<IdentitySecurityLogDto>(
                count,
                ObjectMapper.Map<List<IdentitySecurityLog>, List<IdentitySecurityLogDto>>(list)
            );
        }
        public async Task<PagedResultDto<IdentitySecurityLogDto>> GetUserListAsync(IdentitySecurityLogPageInput input)
        {
            var count = (long)await _identitySecurityLogRepository.GetCountAsync(input.startTime, input.endTime,
                 input.applicationName, input.identity, input.actions,CurrentUser.Id,
                 input.userName, input.clientId, input.correlationId);

            var list = await _identitySecurityLogRepository.GetListAsync(input.Sorting, input.MaxResultCount,
                input.SkipCount, input.startTime, input.endTime,
                 input.applicationName, input.identity, input.actions, CurrentUser.Id,
                 input.userName, input.clientId, input.correlationId);

            return new PagedResultDto<IdentitySecurityLogDto>(
                count,
                ObjectMapper.Map<List<IdentitySecurityLog>, List<IdentitySecurityLogDto>>(list)
            );
        }
    }
}
