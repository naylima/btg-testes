using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Web.Api.Infrastructure.EntityFramework.Entity
{
    [Table("location")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdLocation { get; set; }

        [Required(ErrorMessage="Latitude is mandatory",AllowEmptyStrings=false)]
        public decimal Latitude { get; set; }

        [Required(ErrorMessage="Longitude is mandatory",AllowEmptyStrings=false)]
        public decimal Longitude { get; set; }

        [Required(ErrorMessage="Galaxy name is mandatory",AllowEmptyStrings=false)]
        public string GalaxyName { get; set; }
        
        [ForeignKey("Rebel")]
        public long IdRebel { get; set; }
        public virtual Rebel Rebel { get; set; }
    }
}