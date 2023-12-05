using System.ComponentModel.DataAnnotations;
using src.Web.Api.Infrastructure.EntityFramework;

namespace src.Web.Api.Model
{
    public class InventoryRequest
    {
        [EnumDataType(typeof(ResourceType))]
        [Required(ErrorMessage="Resource is mandatory",AllowEmptyStrings=false)]
        public string Resource { get; set; }

        [Required(ErrorMessage="Quantity is mandatory")]
        public long Quantity { get; set; }
    }
}