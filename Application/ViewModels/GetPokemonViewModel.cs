using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class GetPokemonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string PrimaryType { get; set; }
        public string SecondaryType { get; set; }
        public string Region { get; set; }
    }
}
