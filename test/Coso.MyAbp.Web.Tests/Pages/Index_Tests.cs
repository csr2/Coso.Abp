using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Coso.MyAbp.Pages
{
    public class Index_Tests : MyAbpWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
