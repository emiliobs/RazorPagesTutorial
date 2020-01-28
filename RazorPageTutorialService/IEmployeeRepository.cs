using RazorPageTutorialModels.Models;
using System.Collections.Generic;

namespace RazorPageTutorialService
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetemployeById(int id);
        Employee Update(Employee employee);
        Employee Add(Employee newEmployee);
        Employee Delete(int id);

        IEnumerable<DeptHeadCount> EmployeeCountByDepartment();

    }
}
