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
    public class IndexModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;

        public IEnumerable<Employee> Employees { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public IndexModel(IEmployeeRepository employeeRepository)
        {
            
            _employeeRepository = employeeRepository;
        }

        public void OnGet()
        {
            //Employees = _employeeRepository.GetAllEmployees();
            Employees = _employeeRepository.Search(SearchTerm);
        }
    }
}