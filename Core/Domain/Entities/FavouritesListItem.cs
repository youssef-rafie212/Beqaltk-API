using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class FavouritesListItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Guid FavouritesListId { get; set; }

        public Product? Product { get; set; }

        public FavouritesList? FavouritesList { get; set; }
    }
}
