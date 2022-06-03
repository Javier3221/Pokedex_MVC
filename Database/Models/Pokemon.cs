using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }

        public int PrimaryTypeId { get; set; }
        public int SecondaryTypeId { get; set; }
        public int RegionId { get; set; }

        //Navigation property
        public PokemonType PrimaryType { get; set; }
        public PokemonType SecondaryType { get; set; }
        public Region Region { get; set; }
    }
}
