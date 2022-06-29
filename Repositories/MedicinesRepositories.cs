using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicManagement.Interfaces;
using ClinicManagement.Models;
using ClinicManagement.Tools;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Repositories
{
    public class MedicinesRepositories : IMedicines
    {
        public readonly ClinicManagementDbContext _context;
        public MedicinesRepositories(ClinicManagementDbContext context)
        {
            _context=context;
        }
        public Medicines Create(Medicines medicines)
        {
            _context.Medicines.Add(medicines);
            _context.SaveChanges();
            return medicines;
        }

        public Medicines Delete(Medicines medicines)
        {
            _context.Attach(medicines);
            _context.Entry(medicines).State=EntityState.Deleted;
            _context.SaveChanges();
            return medicines;
        }

        public Medicines Edit(Medicines medicines)
        {
            _context.Attach(medicines);
            _context.Entry(medicines).State=EntityState.Modified;
            _context.SaveChanges();
            return medicines;
        }

      

        public PaginatedList<Medicines> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<Medicines> medicines;

            if (SearchText != "" && SearchText!=null)
            {
                medicines = _context.Medicines                                 
                            .Where(n => (n.Name.Contains(SearchText) || n.Description.Contains(SearchText)))
                            .ToList();            
            }
            else
            {
                    medicines= _context.Medicines                                   
                                   .ToList();
            }
                

            medicines = DoSort(medicines,SortProperty,sortOrder);
            
            PaginatedList<Medicines> retCategories = new PaginatedList<Medicines>(medicines, pageIndex, pageSize);

            return retCategories;
        }
        public List<Medicines> GetItemsSelectlist()
        {
            //List<Category> categories;

            
                // categories = _context.Categories
                //             .Include(p=>p.ParentCategory)
                //             .Include(c=>c.CategoryChildren)
                //             .Where(n => n.ParentCategory==null)
                //             .ToList();            
           var qr = (from c in _context.Medicines select c)
                     .Include(c => c.Units)
                     .Include(c => c.Manufacture);

            var medicines = (qr.ToList())
                             //.Where(c => c.ParentCategory == null)
                             .ToList();   

            return medicines;
        }

        private List<Medicines> DoSort(List<Medicines> medicines,string SortProperty,SortOrder sortOrder)
        {
             if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                    medicines = medicines.OrderBy(n => n.Name).ToList();
                else
                    medicines = medicines.OrderByDescending(n => n.Name).ToList();
            }
            else if(SortProperty.ToLower()=="description")
            {
                if (sortOrder == SortOrder.Ascending)
                    medicines = medicines.OrderBy(d => d.Description).ToList();
                else
                    medicines = medicines.OrderByDescending(d => d.Description).ToList();
            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                    medicines = medicines.OrderBy(d => d.DateCreate).ToList();
                else
                    medicines = medicines.OrderByDescending(d => d.DateCreate).ToList();
            }

            return medicines;
        }

        public bool IsMedicinesNameExits(string name)
        {
            bool result= _context.Medicines.Any(c=>c.Name==name);
            return result;
        }

        public bool IsMedicinesNameExits(string name, int id)
        {
            bool result= _context.Medicines.Any(c=>c.Name==name && c.ID==id);
            return result;       
        }
        public Medicines GetMedicines(int? id)
        {
            // Category category=_context.Categories.Where(c=>c.ID==id).FirstOrDefault();
            //  var kq = _context.Medicines
            //                 .Include(p=>p.Units)
            //                 .Include(c=>c.Manufacture);
            //   Category  category=kq.ToList()            
            //                 .Where(c=>c.ID==id)
            //                 .FirstOrDefault();        
            Medicines medicines=_context.Medicines.Where(c=>c.ID==id).FirstOrDefault();    
            return medicines;
        }
       


        // public List<Category> GetChildCategory(int? parentId)
        // {

        //          var qr = (from c in _context.Categories select c)
        //              .Include(c => c.ParentCategory)
        //              .Include(c => c.CategoryChildren);

        //     var categories = (qr.ToList())
        //                      .Where(c => c.ParentCategoryID == parentId)
        //                      .ToList();   

        //         return categories;
        // }
    }
}