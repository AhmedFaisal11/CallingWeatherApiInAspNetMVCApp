using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiInMVC.Models
{
    public class SearchCity
    {
        [Required(ErrorMessage ="You must Enter a city Name")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$" , ErrorMessage ="No Special Character allowed")]
        [StringLength(20, MinimumLength =2 , ErrorMessage ="Enter City Name greater than 2 and less than 20")]
        [Display(Name = "CityName")]
        [DataType(DataType.Text)]
        public string CityName { get; set; }
    }
}
