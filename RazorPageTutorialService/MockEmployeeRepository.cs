using RazorPageTutorialModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorPageTutorialService
{
    public class MockEmployeeRepository   : IEmployeeRepository
    {

        private List<Employee> _employeesList;

        public MockEmployeeRepository()
        {
            _employeesList = new List<Employee>()
            {
               new Employee()
               {
                  Id = 1,
                   Name = "Emilio",
                   Department= Department.IT,
                   Email = "emilio@gmail.com",
                   PhotoPath="perro.jpg",
               },
               new Employee()
               {
                   Id = 2, Name = "Mary",
                   Department= Department.HR,
                   Email = "mary@gmail.com",
                   PhotoPath="",
               },
               new Employee()
               {
                  Id = 3,
                   Name = "Sara",
                   Department= Department.None,
                   Email = "sara@gmail.com",
                   PhotoPath="gato.jpeg",
               },
               new Employee()
               {
                  Id = 4,
                   Name = "Pier",
                   Department= Department.Payroll,
                   Email = "pier@gmail.com",
                   PhotoPath="boa.jpeg",
               },
               new Employee()
               {
                  Id = 5,
                   Name = "Chelsay",
                   Department= Department.IT,
                   Email = "chalsay@gmail.com",
                   PhotoPath="airpads.jpg",
               },
                new Employee()
               {
                  Id = 6,
                   Name = "Lorena",
                   Department= Department.Payroll,
                   Email = "lorena@gmail.com",
                   PhotoPath="minipig1.jpg",
               },
            };

           
        }

       

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeesList;
        }

        public Employee GetemployeById(int id)
        {
            return _employeesList.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee editEmployee)
        {
            var employee = _employeesList.FirstOrDefault(e=> e.Id == editEmployee.Id);

            if (employee != null)
            {
                employee.Name = editEmployee.Name;
                employee.Email = editEmployee.Email;
                employee.Department = editEmployee.Department;
                employee.PhotoPath = editEmployee.PhotoPath;
            }

            return employee;
        }
    }
}
