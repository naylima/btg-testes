using System.ComponentModel.DataAnnotations;

namespace src.Web.Api.Model
{
    public class LocationRequest
    {
        [Required(ErrorMessage="Latitude is mandatory",AllowEmptyStrings=false)]
        public decimal Latitude { get; set; }

        [Required(ErrorMessage="Longitude is mandatory",AllowEmptyStrings=false)]
        public decimal Longitude { get; set; }

        [Required(ErrorMessage="Galaxy name is mandatory",AllowEmptyStrings=false)]
        public string GalaxyName { get; set; }
    }
}