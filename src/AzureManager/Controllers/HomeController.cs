using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AzureManager.Domain.Services.Contracts;
using Microsoft.Rest;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using AzureManager.Domain.Services;
using Microsoft.Extensions.OptionsModel;
using AzureManager.Settings;

namespace AzureManager.Web.Controllers
{
 
    public class HomeController : Controller
    {
        private IAuthenticationService authenticationService;
        private IOptions<AppSettings> appSettings;

        public HomeController(IAuthenticationService authenticationService, IOptions<AppSettings> appSettings)
        {
            this.authenticationService = authenticationService;
            this.appSettings = appSettings;
        }

        public async Task<IActionResult> Index()
        {
            var credentials = await this.authenticationService.Auth();

            //ResourceGroupService rgServices = new ResourceGroupService(this.authenticationService);

            //string rgSourceName = "move-work-source";
            //string rgTargetName = "move-work-target";

            //var rgTarget = await rgServices.GetResourceGroup(rgTargetName);

            //var rg = await rgServices.GetResources(rgSourceName);

            //var storageId = "/subscriptions/ae25a641-e0fd-4c5f-a5fb-b1bbc509b5f7/resourceGroups/move-work-source/providers/Microsoft.ClassicStorage/storageAccounts/storagesourceis";

            //var response = await rgServices.MoveResources(rgSourceName, new List<string>() { storageId }, rgTarget.Id).ConfigureAwait(false);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
