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
    public class CategoryController : Controller
    {
        //private readonly ClinicManagementDbContext _context;
        private readonly ICategory _category;
         [TempData]
        public string StatusMessage { get; set;}
        public CategoryController(ICategory category)
        {
            //_context = context;
            _category=category;
        }

        // GET: CategoryCotroller
        public IActionResult Index(string sortExpression="", string SearchText = "",int pg=1,int pageSize=5)
        {
            SortModel sortModel=new SortModel();
            sortModel.AddColumn("name");
            sortModel.AddColumn("description");
            sortModel.AddColumn("ParentCategory");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;


            ViewBag.SearchText=SearchText;
            PaginatedList<Category> categories=_category.GetItems(sortModel.SortedProperty,sortModel.SortedOrder,SearchText,pg,pageSize);

            var pager=new PagerModel(categories.TotalRecords,pg,pageSize);
            pager.SortExpression=sortExpression;
            this.ViewBag.Pager=pager;

            TempData["CurrentPage"]=pg;
            return View(categories);

            // var clinicManagementDbContext = _context.Categories.Include(c => c.ParentCategory);
            // return View(await clinicManagementDbContext.ToListAsync());

        }

       private void CreateSelectItems(List<Category> source, List<Category> des, int level)
        {
            string prefix = string.Concat(Enumerable.Repeat("----", level));
            foreach (var category in source)
            {
                // category.Title = prefix + " " + category.Title;
                des.Add(new Category() {
                    ID = category.ID,
                    Name = prefix + " " + category.Name
                });
                if (category.CategoryChildren?.Count > 0)
                {
                    CreateSelectItems(category.CategoryChildren.ToList(), des, level +1);
                }
            }
        }
        public IActionResult Create()
        {
            var listCategory=_category.GetItemsSelectlist();
            listCategory.Insert(0,new Category{ID=-1,Name="không có danh mục cha"});
            var items = new List<Category>();
            CreateSelectItems(listCategory, items, 0);
            var selectList = new SelectList(items, "ID", "Name");

            ViewBag.ParentCategoryID = selectList;

            Category category = new Category();
            return View(category);
        }

        [HttpPost]  
        public IActionResult Create(Category category)
        {
            bool bolret = false;
            string errMessage = "";
            try
            {               

                if (_category.IsCategoryNameExits(category.Name) == true)
                    errMessage = errMessage + " " + " Tên danh mục " + category.Name +" đã tồn tại";

                if (ModelState.IsValid)
                {
                     if (category.ParentCategoryID == -1) category.ParentCategoryID  = null;
                    category = _category.Create(category);
                    bolret = true;
                }                
            }
            catch(Exception ex) 
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (bolret == false)
            {
                //TempData["ErrorMessage"] = errMessage;\
                //StatusMessage=errMessage;
                 var listCategory=_category.GetItemsSelectlist();
                    listCategory.Insert(0,new Category{ID=-1,Name="không có danh mục cha"});
                    var items = new List<Category>();
                    CreateSelectItems(listCategory, items, 0);
                    var selectList = new SelectList(items, "ID", "Name");

                    ViewBag.ParentCategoryID = selectList;
                        return View(category);

            }
            else
            {
                //TempData["SuccessMessage"] 
                StatusMessage= "Danh mục " + category.Name + " Tạo mới danh mục thành công";
                return RedirectToAction(nameof(Index));
            }
        }
        public IActionResult Details(int id) //read
        {
             Category category =_category.GetCategory(id);              
            return View(category);        
        }

        
        public IActionResult Edit(int id)
        {
             var listCategory=_category.GetItemsSelectlist();
                    listCategory.Insert(0,new Category{ID=-1,Name="không có danh mục cha"});
                    var items = new List<Category>();
                    CreateSelectItems(listCategory, items, 0);
                    var selectList = new SelectList(items, "ID", "Name");

                    ViewBag.ParentCategoryID = selectList;
            Category category = _category.GetCategory(id);
            //TempData.Keep();
            return View(category);
        }  
        
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            bool bolret = false;
            string errMessage = "";

            try
            {
               if (_category.IsCategoryNameExits(category.Name, category.ID) == true)
                    errMessage = errMessage + "Tên danh mục " + category.Name + " đã tồn tại";
                //bool checkdmcha=_category.CanUpdate(category.CategoryChildren,category.ID);
                if (errMessage == "")
                {
                     if (category.ParentCategoryID == -1) category.ParentCategoryID  = null;
                    category = _category.Edit(category);
                    StatusMessage= category.Name + " Danh mục lưu thành công";
                    bolret = true;
                }
            }
            catch(Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;                
            }

          

            int currentPage = 1;
            if (TempData["CurrentPage"] != null)
                currentPage = (int)TempData["CurrentPage"];

          
            if(bolret==false)
            {
                //StatusMessage = errMessage;
                ModelState.AddModelError("", errMessage);
                 var listCategory=_category.GetItemsSelectlist();
                    listCategory.Insert(0,new Category{ID=-1,Name="không có danh mục cha"});
                    var items = new List<Category>();
                    CreateSelectItems(listCategory, items, 0);
                    var selectList = new SelectList(items, "ID", "Name");

                    ViewBag.ParentCategoryID = selectList;
                return View(category);
            }
            else
            return RedirectToAction(nameof(Index),new {pg=currentPage});
        }

        // GET: Unit/Delete/5
        public IActionResult Delete(int id)
        {
            Category category = _category.GetCategory(id);
            TempData.Keep();
            return View(category);
        }

        
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            try
            {
                category = _category.Delete(category);
            }
            catch(Exception ex)
            {
                string errMessage = ex.Message;
                //StatusMessage = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(category);
            }          
            
            int currentPage = 1;
            if (TempData["CurrentPage"] != null)
                currentPage = (int)TempData["CurrentPage"];

            StatusMessage= "Danh mục " + category.Name + " xóa thành công";
            return RedirectToAction(nameof(Index), new { pg = currentPage });


        }
    
        
        // GET: CategoryCotroller/Details/5
        // public async Task<IActionResult> Details(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var category = await _context.Categories
        //         .Include(c => c.ParentCategory)
        //         .FirstOrDefaultAsync(m => m.ID == id);
        //     if (category == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(category);
        // }

        // // GET: CategoryCotroller/Create
        // public IActionResult Create()
        // {
        //     ViewData["ParentCategoryID"] = new SelectList(_context.Categories, "ID", "Name");
        //     return View();
        // }

        // // POST: CategoryCotroller/Create
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("ID,Name,Descriptions,ParentCategoryID")] Category category)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(category);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["ParentCategoryID"] = new SelectList(_context.Categories, "ID", "Name", category.ParentCategoryID);
        //     return View(category);
        // }

        // // GET: CategoryCotroller/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var category = await _context.Categories.FindAsync(id);
        //     if (category == null)
        //     {
        //         return NotFound();
        //     }
        //     ViewData["ParentCategoryID"] = new SelectList(_context.Categories, "ID", "Name", category.ParentCategoryID);
        //     return View(category);
        // }

        // // POST: CategoryCotroller/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Descriptions,ParentCategoryID")] Category category)
        // {
        //     if (id != category.ID)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(category);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!CategoryExists(category.ID))
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
        //     ViewData["ParentCategoryID"] = new SelectList(_context.Categories, "ID", "Name", category.ParentCategoryID);
        //     return View(category);
        // }

        // // GET: CategoryCotroller/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var category = await _context.Categories
        //         .Include(c => c.ParentCategory)
        //         .FirstOrDefaultAsync(m => m.ID == id);
        //     if (category == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(category);
        // }

        // // POST: CategoryCotroller/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     var category = await _context.Categories.FindAsync(id);
        //     _context.Categories.Remove(category);
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        // private bool CategoryExists(int id)
        // {
        //     return _context.Categories.Any(e => e.ID == id);
        // }
    }
}