using System.IO;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

using WishList;
using WishList.Data;

using Xunit;

using static Microsoft.AspNetCore.WebHost;

namespace WishListTests
{
    public class AddEntityFrameworkSupportTests
    {

        [Fact(DisplayName = "Configure EntityFramework @configure-entityframework")]
        public void ConfigureEntityFrameworkTest()
        {
            var webHost = CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.NotNull(webHost.Services.GetRequiredService<ApplicationDbContext>());
        }
    }
}
