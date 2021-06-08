using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PremiumGenerator.Models;

namespace PremiumGenerator.Models
{

    public class MemberDetails
    {
            public Occupation occupation = new Occupation();
            public int age;
        
            [Required(ErrorMessage = "Name is required")]
            [Display(Name = "Name: ")]
            [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$",ErrorMessage ="Only Alphabets are allowed.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Date Of Birth is required")]
            [Display(Name = "Date Of Birth: ")]
            [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime DateOfBirth { get; set; }

            [Required(ErrorMessage = "Death-Sum Insured is required")]
            [Display(Name = "Death-Sum Insured: ")]
            [RegularExpression(@"\d+",ErrorMessage = "The amount is not valid.")]
            public double DeathCoverAmount{ get; set; }

            [Required]
            [Display(Name = "Age: ")]
            public int Age
            {
            get
            {
                if (DateOfBirth != DateTime.MinValue)
                {
                    var today = DateTime.Today;
                    age = today.Year - DateOfBirth.Year;
                    if (DateOfBirth > today.AddYears(-age))
                    { age--; }
                }
                return age;
            }
            }

            [Required(ErrorMessage = "Select an Occupation!")]
            [Display(Name = "Occupation: ")]
            public string SelectedItem { get; set; }
            public List<SelectListItem> OccupationType { get; set; }

            public double PremiumAmount { get; set; }
    }
}
