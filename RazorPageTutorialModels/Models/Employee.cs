using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RazorPageTutorialModels.Models
{
  

    public class Employee
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required."), MinLength(3, ErrorMessage = "Name should contain at least 3 character.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format.")]
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public Department? Department { get; set; }


    }
}
