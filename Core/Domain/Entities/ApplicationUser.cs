using Microsoft.AspNetCore.Identity;

namespace Core.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Cart? Cart { get; set; }
        public ICollection<Order>? Orders { get; set; }

        public FavouritesList? FavouritesList { get; set; }

        public IEnumerable<Review>? Reviews { get; set; }
    }
}
