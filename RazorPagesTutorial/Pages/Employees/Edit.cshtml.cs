using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageTutorialModels.Models;
using RazorPageTutorialService;

namespace RazorPagesTutorial
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IEmployeeRepository  employeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _webHostEnvironment = webHostEnvironment;
        }                                                
        
        public Employee Employee { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }
        
        [BindProperty]
        public bool Notify { get; set; }
        public string Message { get; set; }

        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetemployeById(id);

            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(Employee employee)
        {

            if (Photo != null)
            {

                if (employee.PhotoPath != null)
                {
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath,"Images", employee.PhotoPath);
                    System.IO.File.Delete(filePath);
                }

                employee.PhotoPath = processUploadFile();
            }

            Employee =  _employeeRepository.Update(employee);

            return RedirectToPage("Index");
        }

        private string processUploadFile()
        {
            var uniqueFileName = string.Empty;

            if (Photo != null && Photo.Length > 0)
            {
                var uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = $"{Guid.NewGuid().ToString()} _ {Photo.FileName}";
                var filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }

            }

            return uniqueFileName;
        }

        public IActionResult OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "Thank you for turning on notification.";
            }
            else
            {
                Message = "You have turned off email notification";
            }

            TempData["message"] = Message;

            return RedirectToPage("Details", new { id = id});

            //Employee = _employeeRepository.GetemployeById(id);
        }
    }
}