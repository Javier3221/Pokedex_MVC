using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SavePokemonViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name of this Pokémon is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The image of this Pokémon is required")]
        public string ImgUrl { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "The primary type of this Pokémon is required")]
        public int PrimaryTypeId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "The secondary type of this Pokémon is required")]
        public int SecondaryTypeId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "The region of this Pokémon is required")]
        public int RegionId { get; set; }
    }
}
