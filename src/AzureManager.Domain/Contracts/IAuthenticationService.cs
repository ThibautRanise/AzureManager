using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureManager.Domain.Services.Contracts
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authentications this instance.
        /// </summary>
        /// <returns></returns>
        Task<ServiceClientCredentials> Auth();

        /// <summary>
        /// Gets the subscription identifier.
        /// </summary>
        /// <returns></returns>
        string GetSubscriptionId();
    }
}
