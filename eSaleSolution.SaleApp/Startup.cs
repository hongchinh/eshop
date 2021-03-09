using eSaleSolution.SaleApp.Data;
using eSaleSolution.SaleApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;

namespace eSaleSolution.SaleApp
{
    public class Startup
    {
        IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            _env = hostEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();


            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //   .AddCookie(options =>
            //   {
            //       options.LoginPath = "/login";
            //       options.AccessDeniedPath = "/User/Forbidden/";
            //   });


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHttpService, HttpService>();

            services.AddScoped<ILocalStorageService, LocalStorageService>();
            
            services.AddScoped(sp => sp.GetRequiredService<IAuthenticationService>().Initialize());
            // configure http client
            services.AddScoped(x => {
                var apiUrl = new Uri(Configuration["apiUrl"]);
                return new HttpClient() { BaseAddress = apiUrl };
            });
            services.AddOptions();
            services.AddAuthenticationCore();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<CustomAuthenticationStateProvider, CustomAuthenticationStateProvider>();

            services.AddScoped<AuthenticationStateProvider>(
                    p => p.GetService<CustomAuthenticationStateProvider>());


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

          //  app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
