using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.Models
{
    public class PrescriptionsDetail
    {
        public int ID { get; set; }

        public int MedicinesID { get; set; }
        [ForeignKey("MedicinesID")]
        public virtual Medicines Medicines{get;set;}

        public int prescriptionsID{get;set;}
        [ForeignKey("PrescriptionsID")]
        public virtual prescriptions prescriptionsmaster{get;set;}

        

        [Display(Name ="Số ngày Uống")]

        public int No_of_day{get;set;}

        [Display(Name ="Uống trước bữa ăn?")]

        public bool is_Before_Meal{get;set;}

        [Display(Name ="Uống Khi nào?")]
        public string When_To_Take{get;set;}

        public bool isdeleted;
    }
}