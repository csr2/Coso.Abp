using System;
using System.Collections.Generic;
using System.Text;
using Coso.MyAbp.Localization;
using Volo.Abp.Application.Services;

namespace Coso.MyAbp
{
    /* Inherit your application services from this class.
     */
    public abstract class MyAbpAppService : ApplicationService
    {
        protected MyAbpAppService()
        {
            LocalizationResource = typeof(MyAbpResource);
        }
    }
}
