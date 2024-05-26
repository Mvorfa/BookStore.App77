using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarStore.App.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Display(Name = "ModelName")]
        [Required(ErrorMessage = "ModelName is required")]
        public string ModelName { get; set; }


        [Display(Name = "YearOfManufacture")]
        [Required(ErrorMessage = "YearOfManufacture is required")]
        public int YearOfManufacture { get; set; }

        [Display(Name = "MotorPower")]
        [Required(ErrorMessage = "MotorPower is required")]
        public int MotorPower { get; set; }

        [Display(Name = "MaximumSpeed")]
        [Required(ErrorMessage = "MaximumSpeed is required")]
        public int MaximumSpeed { get; set; }

        [Display(Name = "URLimg")]
        [Required(ErrorMessage = "URLimg of pages is required")]
        public string  URLimg{ get; set; }


        //Relationships
        public int Company { get; set; }
        public Company CompanyName { get; set; }

    }
}
