using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureManager.Web.Models
{
    public class MoveResourceViewModel
    {
        public string ResourceGroupSourceId { get; set; }

        public string ResourceGroupTargetId { get; set; }

        public string ResourceToMoveId { get; set; }

    }
}
