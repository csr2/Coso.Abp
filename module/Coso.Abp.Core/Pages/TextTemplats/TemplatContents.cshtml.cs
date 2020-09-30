
using Coso.Abp.Core.Application.TextTemplats.Dtos;
using Coso.Abp.Core.TextTemplats;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.VirtualFileSystem;
using Microsoft.Extensions.FileProviders;
using Volo.Abp.TextTemplating;

namespace Coso.Abp.Core.Pages.TextTemplats
{
    public class TemplatContentsModel : CosoAbpCorePageModel
    {

        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        public string Content { get; set; }

        [BindProperty]
        public TemplateDefinition ViewModel { get; set; }


        private readonly ITemplateDefinitionAppService _templateDefinitionAppService;
        private readonly TemplateDefinitionManager _templateDefinitionManager;
        protected  IVirtualFileProvider VirtualFileProvider { get; }

        public TemplatContentsModel(ITemplateDefinitionAppService templateDefinitionAppService,
            IVirtualFileProvider virtualFileProvider
            , TemplateDefinitionManager templateDefinitionManager)
        {
            _templateDefinitionAppService = templateDefinitionAppService;
            VirtualFileProvider = virtualFileProvider;
            _templateDefinitionManager = templateDefinitionManager;
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {

            ViewModel = _templateDefinitionManager.GetOrNull(Name);
            var filepath = ViewModel.GetVirtualFilePathOrNull();
            var fileInfo = VirtualFileProvider.GetFileInfo(filepath.ToString());
            if (fileInfo == null || fileInfo.IsDirectory)
            {
                return NotFound();
            }
            Content = await fileInfo.ReadAsStringAsync();

            return Page();
        }
    }
}
