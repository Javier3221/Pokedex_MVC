using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PokemonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public int PrimaryTypeId { get; set; }
        public int SecondaryTypeId { get; set; }
        public int RegionId { get; set; }
    }
}
