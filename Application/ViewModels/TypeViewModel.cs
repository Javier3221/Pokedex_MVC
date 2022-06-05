using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class TypeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Type name is required")]
        public string Name { get; set; }
    }
}
