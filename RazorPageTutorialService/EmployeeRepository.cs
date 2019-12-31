using RazorPageTutorialModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorPageTutorialService
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MockEmployeeRepository _mockEmployeeRepository;

        public EmployeeRepository(MockEmployeeRepository mockEmployeeRepository)
        {
            _mockEmployeeRepository = mockEmployeeRepository;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _mockEmployeeRepository.EmployeeList();
        }

        public Employee GetemployeById(int id) => _mockEmployeeRepository.EmployeeList().FirstOrDefault(e => e.Id == id);
    }
}
