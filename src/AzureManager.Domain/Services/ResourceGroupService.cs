using AzureManager.Domain.Services.Contracts;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AzureManager.Domain.Services
{
    /// <summary>
    /// Service used to manage Resource groups
    /// </summary>
    /// <seealso cref="AzureManager.Domain.Services.Contracts.IResourceGroupService" />
    public class ResourceGroupService : IResourceGroupService
    {
        /// <summary>
        /// The authenticate service
        /// </summary>
        IAuthenticationService authenticateService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceGroupService"/> class.
        /// </summary>
        /// <param name="authenticateService">The authenticate service.</param>
        public ResourceGroupService(IAuthenticationService authenticateService)
        {
            this.authenticateService = authenticateService;
        }

        /// <summary>
        /// Moves the resources.
        /// </summary>
        /// <param name="resourceGroupSource">The resource group source.</param>
        /// <param name="resources">The resources.</param>
        /// <param name="resourceGroupTarget">The resource group target.</param>
        /// <returns></returns>
        public async Task<AzureOperationResponse> MoveResources(string resourceGroupSource, IEnumerable<string> resources, string resourceGroupTarget)
        {
            // Get the credentials from the authentication service
            var crendentials = await this.authenticateService.Auth(); 

            using (var rgClient = new ResourceManagementClient(crendentials))
            {
                // Get the subscription id from the authentication service
                rgClient.SubscriptionId = this.authenticateService.GetSubscriptionId();

                ResourcesMoveInfo moveInfos = new ResourcesMoveInfo()
                {
                    Resources = resources.ToList(),
                    TargetResourceGroup = resourceGroupTarget
                };

                return await rgClient.Resources.BeginMoveResourcesWithHttpMessagesAsync(resourceGroupSource, moveInfos);
            }
        }

        public Task<ResourceGroup> GetResourceGroup(string resourceGroup)
        {
            throw new NotImplementedException();
        }

        public Task<IPage<GenericResource>> GetResources(string resourceGroup)
        {
            throw new NotImplementedException();
        }
    }
}
