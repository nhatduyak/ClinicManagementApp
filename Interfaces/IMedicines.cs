using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicManagement.Models;
using ClinicManagement.Tools;

namespace ClinicManagement.Interfaces
{
    public interface IMedicines
    {
        PaginatedList<Medicines> GetItems(string SortProperty,SortOrder sortOrder,string SearchText="",int pageIndex=1,int pageSize=5);

        Medicines GetMedicines(int? id);

        Medicines Create(Medicines medicines);

        Medicines Edit(Medicines medicines);

        Medicines Delete(Medicines medicines);

        public bool IsMedicinesNameExits(string name);

        public bool IsMedicinesNameExits(string name,int id);
        //public List<Medicines> GetChildCategory(int? parentId);
        //List<Medicines> GetItemsSelectlist();

    }
}