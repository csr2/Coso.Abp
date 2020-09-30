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
    public class CreateModalModel : CosoIdentityPageModel
    {
        //[BindProperty]
        //public string ParentId { get; set; }

        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid? ParentId { get; set; }

        [BindProperty]
        public CreateOrganizationUnitInput OrganizationUnit { get; set; }

        public List<SelectListItem> BaseList { get; set; }

        private readonly IOrganizationUnitAppService _service;

        public CreateModalModel(IOrganizationUnitAppService service)
        {
            _service = service;
        }
        public async Task OnGetAsync()
        {

           // _service.GetChildrenAsync


            await Task.CompletedTask;
        }
        public async Task<ObjectResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateOrganizationUnitInput, OrganizationUnitInput>(OrganizationUnit);
            dto.ParentId = ParentId;

           var unit= await _service.CreateAsync(dto);

            return new ObjectResult(unit);
        }
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    OrganizationUnit.ParentId = ParentId;

        //    await _service.CreateAsync(OrganizationUnit);
        //    return NoContent();
        //}
    }
}