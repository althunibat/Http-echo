using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HttpEcho.Web {
    public class Startup {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddHttpClient();
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration config,
            IHttpClientFactory clientFactory, ILoggerFactory loggerFactory) {
            var logger = loggerFactory.CreateLogger<Startup>();
            app.UseRouting();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseEndpoints(ep => {
                ep.MapGet("/", async ctx => {
                    var msg = config["MSG"] ?? "Hello!!";
                    var next = config["NEXT"] ?? "";
                    if (!string.IsNullOrWhiteSpace(next)) {
                        var client = clientFactory.CreateClient("next");
                        var response = await client.GetStringAsync(next);
                        msg = string.Concat(msg, " ", response);
                    }

                    logger.LogInformation($"Message:- {msg}");
                    await ctx.Response.WriteAsync(msg);
                });
            });
        }
    }
}