using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Web.Api.Infrastructure.EntityFramework.Entity
{
    [Table("resource")]
    public class Resource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdResource { get; set; }

        [Required(ErrorMessage="Resoucer name is mandatory",AllowEmptyStrings=false)]
        [MaxLength(9)]
        public string Name { get; set; }
        public long Quantity { get; set; }
        
    }
}