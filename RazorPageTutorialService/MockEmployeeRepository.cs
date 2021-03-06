﻿using RazorPageTutorialModels.Models;
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

        public Employee Add(Employee newEmployee)
        {
            newEmployee.Id = _employeesList.Max(e => e.Id) + 1;
            _employeesList.Add(newEmployee);
            return newEmployee;
        }

        public Employee Delete(int id)
        {
           var employeeToDelete =  _employeesList.FirstOrDefault(e => e.Id == id);

            if (employeeToDelete != null)
            {
                _employeesList.Remove(employeeToDelete);
            }

            return employeeToDelete;
        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDepartment(Department? department)
        {

            IEnumerable<Employee> query = _employeesList;

            if (department.HasValue)
            {
                query = query.Where(e => e.Department == department.Value);
            }

           return query.GroupBy(e => e.Department)
                .Select(g => new DeptHeadCount { 
                    Department = g.Key.Value,
                    Count = g.Count()
            }).ToList();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeesList;
        }

        public Employee GetemployeById(int id)
        {
            return _employeesList.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> Search(string searchTem)
        {
            if (string.IsNullOrEmpty(searchTem))
            {
                return _employeesList;
            }

            return _employeesList.Where(e => e.Name.Contains(searchTem) || e.Email.Contains(searchTem));
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
