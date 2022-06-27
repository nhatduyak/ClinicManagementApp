using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.Models
{
    public class MedicinesCategory
    {
        public int MedicinesID{get;set;}
        [ForeignKey("MedicinesID")]
        public Medicines Medicines{get;set;}


         public int CategoryID{get;set;}
        [ForeignKey("CategoryID")]
        public Category Category{get;set;}
    }
}