using Microsoft.AspNetCore.Mvc;
using RazorPageTutorialService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesTutorial.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HeadCountViewComponent(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IViewComponentResult Invoke()
        {
            var result = _employeeRepository.EmployeeCountByDepartment();

            return View(result);
        }
    }
}
