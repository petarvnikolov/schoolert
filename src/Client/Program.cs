using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Schoolert.Client;
using Havit.Blazor.Components.Web;
using Havit.Blazor.Components.Web.Bootstrap;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddLocalization();
        builder.Services.AddHxServices();

        var host = builder.Build();
        await host.SetDefaultCulture();
        await host.RunAsync();
    }
}