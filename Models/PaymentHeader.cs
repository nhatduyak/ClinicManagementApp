using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.Models
{
    public class PaymentHeader
    {
        [Key]
        public int ID{get;set;}

        public string Code{get;set;}=DateTime.Now.ToString("yyyyMMddhhmmss");


        [Display(Name ="Ngày tạo")]
        [DataType(DataType.Date)]
        public DateTime DateCreate{get;set;}

         [Display(Name ="Tổng tiền")]
        [DisplayFormat(DataFormatString ="{0:0.000}",ApplyFormatInEditMode =true)]
        public decimal? Total{get;set;}    


        public int PatientID { get; set; }
        [ForeignKey("PatientID")]
        public Patient Patient{get;set;}

      public ICollection<PaymentDetail> PaymentDetail { get; set; }

      

    }
}