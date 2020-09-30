using System;

namespace Coso.Abp.Core.Auditing.Dtos
{
    public class GetAverageExecutionDurationPerDayInput
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}