using System.ComponentModel.DataAnnotations;

namespace Core.DTO.FavourtiesListItemsDtos
{
    public class CreateFavouritesListItemDto
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Guid FavouritesListId { get; set; }
    }
}
