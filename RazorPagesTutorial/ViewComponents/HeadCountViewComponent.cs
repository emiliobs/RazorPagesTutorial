using Microsoft.AspNetCore.Mvc;
using RazorPageTutorialModels.Models;
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

        public IViewComponentResult Invoke(Department? departmentName = null) 
        {
            var result = _employeeRepository.EmployeeCountByDepartment(departmentName);

            return View(result);
        }
    }
}
