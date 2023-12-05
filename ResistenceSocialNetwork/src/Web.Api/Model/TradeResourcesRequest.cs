using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace src.Web.Api.Model
{
    public class TradeResourcesRequest
    {
        [Required(ErrorMessage="Rebel is mandatory")]
        public RebelAndResouces FirstRebel { get; set; }

        [Required(ErrorMessage="Rebel is mandatory")]
        public RebelAndResouces SecondRebel { get; set; }

        public class RebelAndResouces
        {
            [Required(ErrorMessage="Identity rebel is mandatory")]
            public long IdRebel { get; set; }

            [Required(ErrorMessage="Inventory is mandatory")]
            public List<InventoryRequest> Inventories { get; set; }
        }
    }
}