using BlazorChat.Data;
using BlazorChat.Repos;
using BlazorChat.Services;
using BlazorChat.SignalRServer;
using Blazored.SessionStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace BlazorChat
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazoredSessionStorage();
            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<CryptoDataRepo>();
            services.AddSingleton<CryptoDataService>();
            services.AddSingleton<ICryptoGenerator, CryptoGenerator>();
            services.AddSingleton<CryptoState>();
            services.AddScoped<ChatState>().AddScoped<ISessionStorageService, SessionStorageService>();
            services.AddHostedService<CryptoBackgroundWorker>();
            services.AddBlazorise(options =>
                   {
                       options.ChangeTextOnKeyPress = true; // optional
                   })
                    .AddBootstrapProviders()
                    .AddFontAwesomeIcons();
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                endpoints.MapHub<BlazorChatSampleHub>(BlazorChatSampleHub.HubUrl);
                endpoints.MapHub<CryptoHub>(CryptoHub.HubUrl);
            });

            app.ApplicationServices
              .UseBootstrapProviders()
              .UseFontAwesomeIcons();
        }
    }
}
