using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageTutorialModels.Models;
using RazorPageTutorialService;

namespace RazorPagesTutorial
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;

        public Employee Employee { get; set; }
        
        [TempData]
        public string Message { get; set; }

        public DetailsModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public  IActionResult  OnGet(int id )
        {             

            Employee = _employeeRepository.GetemployeById(id);

            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();


        }
    }
}