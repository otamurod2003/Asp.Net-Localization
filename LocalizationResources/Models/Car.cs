using System.ComponentModel.DataAnnotations;

namespace LocalizationResources.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Car name field not required")]
        [Display(Name ="CarName")]
        public string? CarName { get; set; }
        [Display(Name = "Price")]
        [Required(ErrorMessage ="Price field not required")]
        public int? Price { get; set; }
    }
}
