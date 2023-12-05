using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Web.Api.Infrastructure.EntityFramework.Entity
{
    [Table("inventory")]
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdInventory { get; set; }

        [Required(ErrorMessage="Resource is mandatory",AllowEmptyStrings=false)]
        public string Resource { get; set; }

        [Required(ErrorMessage="Quantity is mandatory")]
        public long Quantity { get; set; }
        [ForeignKey("Rebel")]
        public long IdRebel { get; set; }
        public virtual Rebel Rebel { get; set; }
    }
}