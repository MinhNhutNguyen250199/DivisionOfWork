using Blazored.LocalStorage;
using Blazored.Toast;
using DivisionOfWork.ServicesAPI;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DivisionOfWork
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            //builder.RootComponents.Add<App>("#app");
            builder.Services.AddBlazoredToast();
            builder.Services.AddTransient<ITaskAPiClient, TaskAPIClient>();
            builder.Services.AddTransient<IUSerAPIClient, UserApiClient>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            //builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            //builder.Services.AddScoped<IAuthService, AuthService>();
            //builder.Services.AddScoped(sp => new HttpClient;

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
