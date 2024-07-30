using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class FavouritesList
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public ICollection<FavouritesListItem>? FavouritesListItems { get; set; }
    }
}
