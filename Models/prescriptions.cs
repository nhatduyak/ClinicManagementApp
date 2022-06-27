using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.Models
{
    public class prescriptions
    {
        [Key]
        public int ID{get;set;}

        public int PatientID{get;set;}
        [ForeignKey("PatientID")]
        public Patient Patient{get;set;}

          public int DoctorID{get;set;}
        [ForeignKey("DoctorID")]
        public Doctor Doctor{get;set;}


        [Display(Name ="Ngày tạo")]
        public DateTime? DateCreate{get;set;}  =DateTime.Now;

        [Display(Name ="Ngày tái khám")]
        public DateTime? NextVisit{get;set;} 

        [Display(Name ="Lời khuyên")]
        [StringLength(200,ErrorMessage ="{0} phải từ 0 đến {1} ký tự")]
        public string advice { get; set; }


         [Display(Name ="Ghi chú")]
        [StringLength(200,ErrorMessage ="{0} phải từ 0 đến {1} ký tự")]
        public string Note { get; set; }
        
    }
}