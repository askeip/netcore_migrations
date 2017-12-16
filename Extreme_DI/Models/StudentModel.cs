using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Extreme_DI.Models
{
    public class StudentModel
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int StudentID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Range(1, 8)]
        [Display(Name = "Course")]
        public int Course { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [Display(Name = "Group's Name")]
        public string Group { get; set; }

        [Required]
        [Display(Name = "Years to graduate left")]
        public int YeargsToGraduate { get; set; }
    }
}
