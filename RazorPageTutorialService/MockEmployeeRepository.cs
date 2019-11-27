using RazorPageTutorialModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPageTutorialService
{
    public class MockEmployeeRepository : IEmployeeRepository
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
                   PhotoPath="emilio.pmg",
               },
               new Employee()
               {
                   Id = 2, Name = "Mary",
                   Department= Department.HR,
                   Email = "mary@gmail.com",
                   PhotoPath="mary.pmg",
               },
               new Employee()
               {
                  Id = 3,
                   Name = "Sara",
                   Department= Department.None,
                   Email = "sara@gmail.com",
                   PhotoPath="sara.pmg",
               },
               new Employee()
               {
                  Id = 4, 
                   Name = "Pier",
                   Department= Department.Payroll,
                   Email = "pier@gmail.com",
                   PhotoPath="pier.pmg",
               },
               new Employee()
               {
                  Id = 1,
                   Name = "Chelsay",
                   Department= Department.IT,
                   Email = "chalsay@gmail.com",
                   PhotoPath="chalsay.pmg",
               },
            };
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeesList;
        }
    }
}
