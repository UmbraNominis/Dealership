﻿using Dealership.Entities.Enums.Cars;
using Dealership.Entities.Validations;
using System.ComponentModel.DataAnnotations;

namespace Dealership.Entities.AbstractClasses.CarsForSale
{
    public abstract class CarForSaleProperties
    {
        [Required]
        public Brand Brand { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "This Field Is Required!")]
        [MaxLength(50, ErrorMessage = "Cannot be Longer than 50 Characters!")]
        public string ModelName { get; set; }

        [Required(ErrorMessage = "This Field Is Required!")]
        [Range(1950, 2024)]
        public int Year { get; set; }

        [Display(Name = "Body Type")]
        [Required(ErrorMessage = "This Field Is Required!")]
        public BodyType BodyType { get; set; }

        [Required(ErrorMessage = "This Field Is Required!")]
        [MaxLength(50, ErrorMessage = "Cannot be Longer than 50 Characters!")]
        public string Color { get; set; }

        [Required(ErrorMessage = "This Field Is Required!")]
        public Transmission Transmission { get; set; }

        [DisplayFormat(DataFormatString = "{0} Miles")]
        [Required(ErrorMessage = "This Field Is Required!")]
        public int Mileage { get; set; }

        [Display(Name = "Engine Type")]
        [Required(ErrorMessage = "This Field Is Required!")]
        public EngineType EngineType { get; set; }

        [DisplayFormat(DataFormatString = "{0:F1} Litre")]
        [ElectricEngineCannotHaveDisplacement]
        [RequiredDisplacementOnNonElectricEngine("This Field is Required!")]
        [Range(0.1, 12.7, ErrorMessage = "{0} Must be Between {1} and {2}")]
        public double? Displacement { get; set; }

        [DisplayFormat(DataFormatString = "{0} Hp")]
        [Required(ErrorMessage = "This Field Is Required!")]
        [Range(1, 1500, ErrorMessage = "{0} Must be Between {1} and {2}")]
        public int Horsepower { get; set; }

        [DisplayFormat(DataFormatString = "{0} Kw")]
        [Required(ErrorMessage = "This Field Is Required!")]
        [Range(1, 1200, ErrorMessage = "{0} Must be Between {1} and {2}")]
        public int Kilowatts { get; set; }

        [Display(Name = "Newton-meters")]
        [DisplayFormat(DataFormatString = "{0} Nm")]
        [Required(ErrorMessage = "This Field Is Required!")]
        [Range(1, 2400, ErrorMessage = "{0} Must be Between {1} and {2}")]
        public int NewtonMeters { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "${0}")]
        [Required]
        [Range(1, 1000000)]
        public int Price { get; set; }

        public string Uploads { get; set; }
    }
}
