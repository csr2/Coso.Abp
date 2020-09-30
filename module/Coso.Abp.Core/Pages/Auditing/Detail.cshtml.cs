using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Coso.Abp.Core.Auditing;
using Coso.Abp.Core.Auditing.Dtos;
using Volo.Abp.AuditLogging;
using Coso.Abp.Core.Pages;

namespace Coso.Abp.Core.Pages.Admin.Auditing
{
    public class DetailModel : CosoAbpCorePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public AuditLogDto AuditLog { get; set; }

        private readonly IAuditLogAppService _service;
        public DetailModel(IAuditLogAppService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            AuditLog = await _service.GetAsync(Id);
        }
    }
}