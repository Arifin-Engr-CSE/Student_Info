using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Info.Data;
using Student_Info.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Info.Controllers
{
    
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentsController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task<IActionResult> Index()
        {
            List<Student> students = await _db.Students.Include(s => s.StudentClass).ToListAsync();
            return View(students);
        }

        //Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["StudentClassId"] = new SelectList(_db.StudentClasses, "StudentClassId", "ClassName");
            return View();
        }

        //Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId", "StudentName", "Address", "AddmissionDate", "StudentClassId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(student);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }
    }
}
