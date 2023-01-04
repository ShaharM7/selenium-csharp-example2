using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeenityAutomation.Selenium.Configuration;
using SeenityAutomation.Selenium.Drivers;
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
            services.Configure<AwaiterConfig>(Configuration.GetSection(nameof(AwaiterConfig)));
            services.Configure<NavigationConfig>(Configuration.GetSection(nameof(NavigationConfig)));

            // --------------------------------- Drivers -----------------------------------------------
            services.AddSingleton<IWebDriver, ChromeBrowser>();
            services.AddSingleton<WebDriverWait, Awaiter>();
            
            // ---------------------------------- Pages ------------------------------------------------
            services.AddSingleton<HomePage>();
            
            // ---------------------------------- Navigation -------------------------------------------
            services.AddSingleton<PageNavigator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}