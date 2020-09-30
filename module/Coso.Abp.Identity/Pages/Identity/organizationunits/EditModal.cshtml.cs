using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System;
using Coso.Abp.Identity.Pages.Identity.organizationunits.ViewModels;
using Coso.Abp.Identity.Application;
using Coso.Abp.Identity.Application.Dtos;

namespace Coso.Abp.Identity.Pages.Identity.organizationunits
{
    public class EditModal : CosoIdentityPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }


        [BindProperty]
        public CreateOrganizationUnitInput OrganizationUnit { get; set; }

        public List<SelectListItem> BaseList { get; set; }

        private readonly IOrganizationUnitAppService _service;

        public EditModal(IOrganizationUnitAppService service)
        {
            _service = service;
        }
        public async Task OnGetAsync()
        {

            var dto = await _service.GetOrganizationUnitByIdAsync(Id);
            OrganizationUnit = ObjectMapper.Map<OrganizationUnitDto, CreateOrganizationUnitInput>(dto);
           // OrganizationUnit.NewDisplayName = dto.DisplayName;
            await Task.CompletedTask;
        }
        public async Task<ObjectResult> OnPostAsync()
        {

            var dto = ObjectMapper.Map<CreateOrganizationUnitInput, UpdateOrganizationUnitInput>(OrganizationUnit);
            var obj= await _service.UpdateAsync(Id,dto);

            return new ObjectResult(obj);

        }
    }
}