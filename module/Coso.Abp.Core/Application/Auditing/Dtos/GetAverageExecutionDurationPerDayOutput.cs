using System;
using System.Collections.Generic;

namespace Coso.Abp.Core.Auditing.Dtos
{
    public class GetAverageExecutionDurationPerDayOutput
    {
        public Dictionary<DateTime, double> Data { get; set; }
    }
}