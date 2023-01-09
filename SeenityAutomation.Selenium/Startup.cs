using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeenityAutomation.Selenium.Configuration;
using SeenityAutomation.Selenium.Drivers;
using SeenityAutomation.Selenium.Drivers.Options;
using SeenityAutomation.Selenium.Navigation;
using SeenityAutomation.Selenium.Pages;

namespace SeenityAutomation.Selenium
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // ------------------------------- Configuration -------------------------------------------
            services.Configure<NavigationConfig>(Configuration.GetSection(nameof(NavigationConfig)));
            services.Configure<AwaiterConfig>(Configuration.GetSection(nameof(AwaiterConfig)));
            services.Configure<BrowserOptionsConfig>(Configuration.GetSection(nameof(BrowserOptionsConfig)));
            services.Configure<RemoteBrowserConfig>(Configuration.GetSection(nameof(RemoteBrowserConfig)));
            
            // ---------------------------------- Pages ------------------------------------------------
            services.AddSingleton<HomePage>();

            // ---------------------------------- Infra -------------------------------------------
            services.AddSingleton<PageNavigator>();
            services.AddSingleton<ChromeOptions, BrowserOptions>();
            
            // --------------------------------- Drivers -----------------------------------------------
            services.AddSingleton<WebDriverWait, Awaiter>();

            var useSeleniumGrid = Configuration.GetValue<bool>("RemoteBrowserConfig:UseSeleniumGrid");
            switch (useSeleniumGrid)
            {
                case true:
                    services.AddSingleton<IWebDriver, RemoteBrowser>();
                    break;
                case false:
                    services.AddSingleton<IWebDriver, ChromeBrowser>();
                    break;
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}