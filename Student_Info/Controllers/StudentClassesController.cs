using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_Info.Controllers;
using Student_Info.Data;
using Microsoft.EntityFrameworkCore;
using Student_Info.Models;
using Microsoft.AspNetCore.Authorization;

namespace Student_Info.Controllers
{
    
    public class StudentClassesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentClassesController(ApplicationDbContext db)
        {
            _db = db;
        }

       
        public async Task<IActionResult> Index()
        {
            return View(await _db.StudentClasses.ToListAsync());
        }

        //Create Class
       
        public IActionResult Create()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("StudentClassId", "ClassName")] StudentClass studentClass)
        {
            if (ModelState.IsValid)
            {
                _db.StudentClasses.Add(studentClass);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentClass);
        }
    }
}
