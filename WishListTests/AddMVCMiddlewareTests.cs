using System.IO;
using System.Text.RegularExpressions;

using WishList;
using WishList.Data;
using Xunit;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

using static Microsoft.AspNetCore.WebHost;

namespace WishListTests
{
    public class AddMVCMiddlewareTests
    {
        [Fact(DisplayName = "Add MVC Middleware to ConfigureServices @add-mvc-middleware-to-configureservices")]
        public void AddMVCCallAdded()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Startup.cs";
            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains("services.AddMvc();"), "`Startup.cs`'s `ConfigureServices` method did not contain a call to `AddMvc`.");
        }

        [Fact(DisplayName = "Configure MVC Middleware In Configure @configure-userouting-middleware-in-configure")]
        public void UseRoutingAdded()
        {
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Startup.cs";
            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains("app.UseRouting();"), "`Startup.cs`'s `Configure` method did not contain a call to `UseRouting` on `app`.");
        }

        [Fact(DisplayName = "Configure MVC Middleware In Configure @configure-useendpoints-middleware-in-configure")]
        public void UseEndpointsAdded()
        {
            var filePath = $"../../../../WishList/Startup.cs";
            string file;
            using (var streamReader = new StreamReader(filePath)) {
                file = streamReader.ReadToEnd();
            }

            Assert.True(file.Contains("app.UseRouting()"),
                "`Startup.cs`'s `Configure` method did not contain a call to `UseRouting` on `app`.");

            Assert.True(file.Contains("app.UseEndpoints"),
                "`Startup.cs`'s `Configure` method did not " +
                "contain a call to `UseEndpoints` " +
                "on `app` after `UseRouting` with an argument of `endpoints => " +
                "{ endpoints.MapDefaultControllerRoute(); }`");
        }
    }
}
