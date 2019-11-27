using RazorPageTutorialModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPageTutorialService
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
    }
}
