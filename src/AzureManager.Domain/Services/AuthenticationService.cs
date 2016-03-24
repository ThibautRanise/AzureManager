using AzureManager.Domain.Services.Contracts;
using System;
using System.Threading.Tasks;
using Microsoft.Rest;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AzureManager.Domain.Services
{
    /// <summary>
    /// Service used to authenticate a user on an Azure Tenant
    /// </summary>
    /// <seealso cref="AzureManager.Domain.Services.Contracts.IAuthenticationService" />
    public class AuthenticationService : IAuthenticationService
    {
        private string clientId;
        private string tenantId;
        private Uri redirectUri;
        private string email;
        private string password;
        private string subscriptionId;

        public AuthenticationService(string clientId, string tenantId, string redirectUri, string email, string password, string subscriptionId)
        {
            this.clientId = clientId;
            this.tenantId = tenantId;
            this.redirectUri = new Uri(redirectUri);
            this.email = email;
            this.password = password;
            this.subscriptionId = subscriptionId;
        }

        /// <summary>
        /// Authenticate a user with an Azure Active Directory App
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceClientCredentials> Auth()
        {
            var context = new AuthenticationContext(string.Format("https://login.microsoftonline.com/{0}", tenantId));

            var authenticationResult = await context.AcquireTokenAsync(
            resource: "https://management.core.windows.net/",
            clientId: clientId,
            userCredential: new UserCredential(this.email, this.password));

            string token = authenticationResult.CreateAuthorizationHeader().Substring("Bearer ".Length);

            return new TokenCredentials(token);
        }

        /// <summary>
        /// Return the souscriptionId
        /// </summary>
        /// <returns></returns>
        public string GetSubscriptionId()
        {
            return this.subscriptionId;
        }
    }
}
