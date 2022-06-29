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
    public class MedicinesController : Controller
    {
        //private readonly ClinicManagementDbContext _context;
        private readonly IMedicines _medicinesrepo;
         [TempData]
        public string StatusMessage { get; set;}
        public MedicinesController(IMedicines medicinesrepo)
        {
            //_context = context;
            _medicinesrepo=medicinesrepo;
        }

        // GET: Medicines
        public IActionResult Index(string sortExpression="", string SearchText = "",int pg=1,int pageSize=5)
        {
             SortModel sortModel=new SortModel();
            sortModel.AddColumn("code");
            sortModel.AddColumn("name");
            sortModel.AddColumn("Category");
            sortModel.AddColumn("unitprice");
            sortModel.AddColumn("SellPrice");
            sortModel.AddColumn("Quantity");
            sortModel.AddColumn("ExpiryDate");
            sortModel.AddColumn("DateCreate");

            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;
               ViewBag.SearchText=SearchText;
            PaginatedList<Medicines> medicines=_medicinesrepo.GetItems(sortModel.SortedProperty,sortModel.SortedOrder,SearchText,pg,pageSize);

            var pager=new PagerModel(medicines.TotalRecords,pg,pageSize);
            pager.SortExpression=sortExpression;
            this.ViewBag.Pager=pager;

            TempData["CurrentPage"]=pg;
            return View(medicines);

        }

        //GET: Medicines/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var medicines = await _context.Medicines
            //     .Include(m => m.Units)
            //     .FirstOrDefaultAsync(m => m.ID == id);
            var medicines=_medicinesrepo.GetMedicines(id);
            if (medicines == null)
            {
                return NotFound();
            }

            return View(medicines);
        }

        // GET: Medicines/Create
        public IActionResult Create()
        {
            
            ViewData["UnitID"] = new SelectList(_medicinesrepo.GetUnitsSelected(), "ID", "Name");
            ViewData["ManufactureID"]=new SelectList(_medicinesrepo.GetManufactureSelected(),"ID","Name");
            ViewData["CategoryId"]=new SelectList(_medicinesrepo.GetCategorySelected(),"ID","Name");
            return View();
        }

        // POST: Medicines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("ID,Code,Name,Description,UnitID,UnitPrice,SellPrice,Quantity,ExpiryDate,OldUnitPrice,OldSellPrice,DateCreate,DateModify,UserID,UserIDModify")] Medicines medicines)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(medicines);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["UnitID"] = new SelectList(_context.Units, "ID", "Name", medicines.UnitID);
        //     return View(medicines);
        // }

        // // GET: Medicines/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var medicines = await _context.Medicines.FindAsync(id);
        //     if (medicines == null)
        //     {
        //         return NotFound();
        //     }
        //     ViewData["UnitID"] = new SelectList(_context.Units, "ID", "Name", medicines.UnitID);
        //     return View(medicines);
        // }

        // // POST: Medicines/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("ID,Code,Name,Description,UnitID,UnitPrice,SellPrice,Quantity,ExpiryDate,OldUnitPrice,OldSellPrice,DateCreate,DateModify,UserID,UserIDModify")] Medicines medicines)
        // {
        //     if (id != medicines.ID)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(medicines);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!MedicinesExists(medicines.ID))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["UnitID"] = new SelectList(_context.Units, "ID", "Name", medicines.UnitID);
        //     return View(medicines);
        // }

        // // GET: Medicines/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var medicines = await _context.Medicines
        //         .Include(m => m.Units)
        //         .FirstOrDefaultAsync(m => m.ID == id);
        //     if (medicines == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(medicines);
        // }

        // // POST: Medicines/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var medicines = await _context.Medicines.FindAsync(id);
        //     _context.Medicines.Remove(medicines);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool MedicinesExists(int id)
        // {
        //     return _context.Medicines.Any(e => e.ID == id);
        // }
    }
}
