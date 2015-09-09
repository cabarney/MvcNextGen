using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Diagnostics;
using Microsoft.Data.Entity;

namespace EmptyWeb
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<TestContext>(options =>
                    options.UseSqlServer(
                        "Server=(localdb)\\MSSQLLocalDB;Database=HdcMorningTest;Trusted_Connection=True;"));

            services.AddTransient<MessageFactory>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseErrorPage();

            app.UseStaticFiles();

            //app.UseMiddleware<TestMiddleware>();

            app.UseMvcWithDefaultRoute();

            app.UseWelcomePage();

            app.Run(async (context) =>
            {
                throw new Exception("Boom!");
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }

    public class TestController
    {
        private readonly MessageFactory _factory;

        public TestController(MessageFactory factory)
        {
            _factory = factory;
        }

        public string Message()
        {
            return _factory.CreateMessage();
        }

        public string Index()
        {
            return "I'm in a Controller!";
        }
    }

    public class TestMiddleware
    {
        RequestDelegate _next;

        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //await context.Response.WriteAsync("Hi.");
            //await _next(context);
            //Debug.WriteLine($"Request: {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}");
            //await _next(context);

            //var sw = new Stopwatch();
            //sw.Start();

            //await _next(context);

            //Debug.WriteLine($"{sw.ElapsedMilliseconds} elapsed");
        }
    }

    public class MessageFactory
    {
        public string CreateMessage()
        {
            return "I've been injected via ASP.NET's built-in Dependency Injection feature!";
        }
    }

    public class Thing
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class TestContext : DbContext
    {
        public DbSet<Thing> Things { get; set; }
    }
}
