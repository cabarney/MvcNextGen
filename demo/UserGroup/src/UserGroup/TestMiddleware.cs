using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace UserGroup
{
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

            //Debug.WriteLine($"Request: {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}");
            //await _next(context);

            //var sw = new Stopwatch();
            //sw.Start();

            //await _next(context);

            //Debug.WriteLine($"{sw.ElapsedMilliseconds} elapsed");
        }
    }
}