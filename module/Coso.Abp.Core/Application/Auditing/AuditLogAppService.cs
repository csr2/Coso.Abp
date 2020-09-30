using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AuditLogging;
using Coso.Abp.Core.Auditing.Dtos;

namespace Coso.Abp.Core.Auditing
{
    public class AuditLogAppService : ApplicationService, IAuditLogAppService
    {
        private readonly IAuditLogRepository _auditLogRepository;
        public AuditLogAppService(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public async Task<AuditLogDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<AuditLog, AuditLogDto>(
                await _auditLogRepository.GetAsync(id)
            );
        }
        public async Task<PagedResultDto<AuditLogDto>> GetListAsync(AuditLogInput input)
        {

            var count = (long)await _auditLogRepository.GetCountAsync(input.StartTime, input.EndTime,
                input.HttpMethod, input.Url, input.UserName, input.ApplicationName,
                input.CorrelationId, input.MaxExecutionDuration, input.MinExecutionDuration,
                input.HasException, input.HttpStatusCode);

            var list = await _auditLogRepository.GetListAsync(input.Sorting, input.MaxResultCount,
                input.SkipCount, input.StartTime, input.EndTime, input.HttpMethod,
                input.Url, input.UserName, input.ApplicationName, input.CorrelationId,
                input.MaxExecutionDuration, input.MinExecutionDuration, input.HasException,
                input.HttpStatusCode, true);

            return new PagedResultDto<AuditLogDto>(
                count,
                ObjectMapper.Map<List<AuditLog>, List<AuditLogDto>>(list)
            );
        }
        public async Task<GetAverageExecutionDurationPerDayOutput> GetAverageExecutionDurationPerDayAsync(GetAverageExecutionDurationPerDayInput input)
        {
            var data = await _auditLogRepository.GetAverageExecutionDurationPerDayAsync(input.StartDate, input.EndDate);
            return new GetAverageExecutionDurationPerDayOutput()
            {
                Data = data
            };
        }
       
    }
}
