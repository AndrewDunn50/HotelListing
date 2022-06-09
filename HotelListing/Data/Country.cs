using System.ComponentModel.DataAnnotations;

namespace HotelListing.Data
{
    public class Country
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(2)]
        public string? ShortName { get; set; }

        public virtual IList<Hotel>? Hotels { get; set; }
    }
}
