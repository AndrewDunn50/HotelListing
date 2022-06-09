using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{
    public abstract class HotelDtoBase
    {
        [Required]
        [StringLength(maximumLength: 50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(maximumLength: 200)]
        public string? Address { get; set; }

        [Required]
        [Range(1,5)]
        public double Rating { get; set; }

        [Required]
        public int CountryId { get; set; }
    }

    public class HotelDto: HotelDtoBase
    {
        public int Id { get; set; }
        public CountryDto? Country { get; set; }
    }

    public class CreateHotelDto : HotelDtoBase
    {
     
    }
}
