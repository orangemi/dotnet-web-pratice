using System.IO;
// using System.Text;
using Microsoft.AspNetCore.Http;
// using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;
// using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

namespace Teambition.Finance {
  public class HttpApplication {
    public void start() {
      var host = new WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .UseStartup<Startup>()
        .Build();

      host.Run();
    }
  }

  class Startup {
    public void ConfigureServices(IServiceCollection services) {
      // services.AddMvc();
      services.AddRouting();
    }

    public void Configure(IApplicationBuilder app) {
      // app.UseMvc(routes => {
      //   routes.MapRoute("default", "{controllerName}/{action=Index}/{id?}");
      // });
      // app.Run(context => {
      //   return context.Response.WriteAsync("Hello World");
      // });
      var routeBuilder = new RouteBuilder(app);
      routeBuilder.MapRoute("api/{item}", context => {
        string item = context.GetRouteValue("item").ToString();
        return context.Response.WriteAsync($"api/{item} is just fine.");
      });
      app.UseRouter(routeBuilder.Build());
    }
  }
}