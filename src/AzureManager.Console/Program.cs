using AzureManager.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using AzureManager.Domain.Services;
using Microsoft.Rest;

namespace AzureManager.Console
{
    public class Program
    {
        public static IConfiguration configuration;

        public static void Main(string[] args)
        {
            IApplicationEnvironment app = PlatformServices.Default.Application;

            // Load configurations stored in appsettings.json
            configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(app.ApplicationBasePath, "appsettings.json"))
                .AddEnvironmentVariables()
                .Build();

            Task.Run(async () =>
            {
                // Create the authentication service
                IAuthenticationService authenticationService = new AuthenticationService
                    (
                        clientId: configuration["AzureADApp:ClientId"],
                        tenantId: configuration["AzureADApp:TenantId"],
                        redirectUri: configuration["AzureADApp:RedirectUri"],
                        email: configuration["AzureAccount:Email"],
                        password: configuration["AzureAccount:Password"],
                        subscriptionId: configuration["AzureAccount:SubscriptionId"]
                    );

                ServiceClientCredentials credentials = await authenticationService.Auth();
            });

            System.Console.Read();
        }
    }
}
