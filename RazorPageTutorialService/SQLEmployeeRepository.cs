using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RazorPageTutorialModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorPageTutorialService
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public Employee Add(Employee newEmployee)
        {
            //_context.Employees.Add(newEmployee);
            //_context.SaveChanges();
            _context.Database.ExecuteSqlRaw("spInsertEmployee {0}, {1}, {2}, {3}", 
                                            newEmployee.Name,
                                            newEmployee.Email,
                                            newEmployee.PhotoPath,
                                            newEmployee.Department);
            return newEmployee;
        }

        public Employee Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }

            return employee;
        }

        public IEnumerable<DeptHeadCount> EmployeeCountByDepartment(Department? departsment)
        {
            IEnumerable<Employee> query = _context.Employees;

            if (departsment.HasValue)
            {
                query = query.Where(e => e.Department == departsment.Value);
            }

            return query.GroupBy(e => e.Department)
                 .Select(g => new DeptHeadCount
                 {
                     Department = g.Key.Value,
                     Count = g.Count()
                 }).ToList();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {

            return _context.Employees.FromSqlRaw<Employee>("Select * From EMployees").OrderBy(e => e.Name);

            //return _context.Employees;
        }

        public Employee GetemployeById(int id)
        {
            SqlParameter parameter = new SqlParameter("@Id", id);
            //return _context.Employees.Find(id);
            return _context.Employees.FromSqlRaw<Employee>("spGetEmployeeById @Id", parameter).ToList().FirstOrDefault();
            //return _context.Employees.FromSqlRaw<Employee>($"spGetEmployeeById {id}").ToList().FirstOrDefault();
        }

        public IEnumerable<Employee> Search(string searchTem)
        {
            if (string.IsNullOrEmpty(searchTem))
            {
                return _context.Employees;
            }

            return _context.Employees.Where(e => e.Name.Contains(searchTem) || e.Email.Contains(searchTem));
        }

        public Employee Update(Employee updateEmployee)
        {
            _context.Update(updateEmployee);
            _context.SaveChanges();
            return updateEmployee;
            
        }
    }
}
