using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? City { get; set; }
        public string? Address { get; set; }
        public int PostalCode { get; set; }
        public Cart? Cart { get; set; }
        public ICollection<Order>? Orders { get; set; }

        public FavouritesList? FavouritesList { get; set; }

        public IEnumerable<Review>? Reviews { get; set; }
    }
}
