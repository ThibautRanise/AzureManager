using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureManager.Domain.Services.Contracts
{
    public interface IResourceGroupService
    {
        /// <summary>
        /// Gets the resources.
        /// </summary>
        /// <param name="resourceGroup">The resource group.</param>
        /// <returns></returns>
        Task<IPage<GenericResource>> GetResources(string resourceGroup);

        /// <summary>
        /// Gets the resource group.
        /// </summary>
        /// <param name="resourceGroup">The resource group.</param>
        /// <returns></returns>
        Task<ResourceGroup> GetResourceGroup(string resourceGroup);

        /// <summary>
        /// Moves the resources.
        /// </summary>
        /// <param name="resourceGroupSource">The resource group source.</param>
        /// <param name="resources">The resources.</param>
        /// <param name="resourceGroupTarget">The resource group target.</param>
        /// <returns></returns>
        Task<AzureOperationResponse> MoveResources(string resourceGroupSource, IEnumerable<string> resources, string resourceGroupTarget);
    }
}
