using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Web.Api.Infrastructure.EntityFramework.Entity
{
    [Table("rebel")]
    public class Rebel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdRebel { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0, 99)]
        public int Age { get; set; }

        [Required]
        [Range(0, 3)]
        public int ReportTraitor { get; set; }

        public bool Traitor { get; set; }
        
        [EnumDataType(typeof(ResourceType))]
        public virtual List<Inventory> Inventories { get; set; }
        public virtual Location Location { get; set; }

        public Rebel(){
            Inventories = new List<Inventory>();
            ReportTraitor = 0;
            Traitor = false;
        }
    }
}