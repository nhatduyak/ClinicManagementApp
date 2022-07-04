using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicManagement.Models;
using ClinicManagement.Interfaces;
using ClinicManagement.Tools;

namespace ClinicManagement.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctor doctorRepo;

        public DoctorController(IDoctor doctor)
        {
            //_context = context;
            doctorRepo=doctor;
        }

        // GET: Doctor
        public IActionResult Index(string sortExpression="", string SearchText = "",int pg=1,int pageSize=5)
        {
            SortModel sortModel=new SortModel();
            sortModel.AddColumn("fname");
            sortModel.AddColumn("lname");
            sortModel.AddColumn("age");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;


            ViewBag.SearchText=SearchText;
            PaginatedList<Doctor> doctors=doctorRepo.GetItems(sortModel.SortedProperty,sortModel.SortedOrder,SearchText,pg,pageSize);

            var pager=new PagerModel(doctors.TotalRecords,pg,pageSize);
            pager.SortExpression=sortExpression;
            this.ViewBag.Pager=pager;

            TempData["CurrentPage"]=pg;
            return View(doctors);
            
        }

        // GET: Doctor/Details/5
        public IActionResult Details(int id)
        {
            
            var doctor= doctorRepo.GetDoctor(id);
         
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctor/Create
        public IActionResult Create()
        {
            Doctor doctor = new Doctor();
            return View(doctor);
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Name,Description,Address,DateCreate")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                // _context.Add(doctor);
                // await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                doctor = doctorRepo.Create(doctor);
                return RedirectToAction(nameof(Index));

            }
            return View(doctor);
        }

        // GET: Doctor/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = doctorRepo.GetDoctor(id);
            if (doctor == null)
            {
                return NotFound();
            }            
            return View(doctor);
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Name,Description,Address,DateCreate")] Doctor doctor)
        {
            if (id != doctor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     doctor = doctorRepo.Edit(doctor);

                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        // GET: Doctor/Delete/5
        public IActionResult Delete(int id)
        {       

            var doctor = doctorRepo.GetDoctor(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var doctor = doctorRepo.GetDoctor(id);
            if(doctor==null)
                return NotFound();

            doctor=doctorRepo.Delete(doctor);
            return RedirectToAction(nameof(Index));
        }
    }
}
