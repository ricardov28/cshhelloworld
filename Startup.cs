using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloWorldWebApp
{
    public class Startup
    {
        // This method is used to configure services for the application.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        // This method is used to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Check if the application is running in development mode.
            if (env.IsDevelopment())
            {
                // Display detailed error pages for development.
                app.UseDeveloperExceptionPage();
            }

            // Enable routing middleware.
            app.UseRouting();

            // Configure endpoints for handling HTTP requests.
            app.UseEndpoints(endpoints =>
            {
                // Map a GET request to the root URL ("/") to this delegate.
                endpoints.MapGet("/", async context =>
                {
                    // Write the "Hello, World!" message to the HTTP response.
                    await context.Response.WriteAsync("Hello, World!");
                });
            });
        }
    }
}
