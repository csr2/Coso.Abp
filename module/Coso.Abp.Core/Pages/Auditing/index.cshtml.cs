using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Coso.Abp.Core.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Coso.Abp.Core.Pages.Admin.Auditing
{
    public class IndexModel : CosoAbpCorePageModel
    {
        public List<SelectListItem> HttpMethodList { get; set; }
        public List<SelectListItem> HttpStatusCodeList { get; set; }

        public void OnGet()
        {
            HttpMethodList = new List<SelectListItem>();
            HttpStatusCodeList = new List<SelectListItem>();

            HttpMethodList.AddRange(Enum.GetValues(typeof(HttpMethod))
              .Cast<HttpMethod>()
              .Select(s => new SelectListItem()
              {
                  Text = s.ToString(),
                  Value = s.ToString()
              })
          );

            HttpStatusCodeList.AddRange(Enum.GetValues(typeof(HttpStatusCode))
                      .Cast<HttpStatusCode>()
                      .Select(state => new SelectListItem()
                      {
                          Text = Convert.ToInt32(Enum.Parse(typeof(HttpStatusCode), state.ToString())).ToString() + " - " + state.ToString(),
                          Value = Convert.ToInt32(Enum.Parse(typeof(HttpStatusCode), state.ToString())).ToString()
                      })
                );
        }

        //public async Task OnGetAsync()
        //{

        //    //HttpMethodList.AddRange(Enum.GetValues(typeof(HttpMethod))
        //    //    .Cast<HttpMethod>()
        //    //    .Select(state => new SelectListItem()
        //    //    {
        //    //        Text = $"TaskState_{state}",
        //    //        Value = state.ToString()
        //    //    })
        //    //);

        //    //var list= Enum.GetValues(typeof(HttpMethod)).Cast<HttpMethod>();


        //    await Task.CompletedTask;
        //}
    }
}