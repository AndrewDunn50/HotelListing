using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{
    public abstract class CountryDtoBase
    {
        [Required]
        [StringLength(maximumLength: 50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(maximumLength: 2)]
        public string? ShortName { get; set; }
    }

    public class CountryDto: CountryDtoBase
    {
        public int Id { get; set; }

        public IList<HotelDto>? Hotels { get; set; }
    }

    public class CreateCountryDto: CountryDtoBase
    {
     
    }
}
