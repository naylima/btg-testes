using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace src.Web.Api.Model
{
    public class RebelRequest
    {

        [Required(ErrorMessage="Rebel name is mandatory",AllowEmptyStrings=false)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage="Rebel age is mandatory")]
        [Range(0, 99)]
        public int Age { get; set; }

        [Required(ErrorMessage="Location is mandatory")]
        public LocationRequest Location { get; set; }
        
        [Required(ErrorMessage="Inventory is mandatory")]
        public ICollection<InventoryRequest> Inventories { get; set; }
    }
}