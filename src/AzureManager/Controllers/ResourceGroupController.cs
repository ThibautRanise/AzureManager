using AzureManager.Domain.Services.Contracts;
using AzureManager.Settings;
using AzureManager.Web.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureManager.Web.Controllers
{
    public class ResourceGroupController : Controller
    {

        private IResourceGroupService resourceGroupService;
        private IOptions<AppSettings> appSettings;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="resourceGroupService"></param>
        /// <param name="appSettings"></param>
        public ResourceGroupController(IResourceGroupService resourceGroupService, IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings;
            this.resourceGroupService = resourceGroupService;
        }

        [HttpPost]
        public async Task<IActionResult> Move(MoveResourceViewModel moveViewModel)
        {      
            var response = await this.resourceGroupService.MoveResources(
                    moveViewModel.ResourceGroupSourceId, 
                    new List<string>() { moveViewModel.ResourceToMoveId },
                    moveViewModel.ResourceGroupTargetId)
             .ConfigureAwait(false);
            return View();
        }
    }
}
