using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.Models
{
    public class Medicines
    {
        [Key]
        public int ID { get; set; }

         [Display(Name ="Code")]
        public string Code { get; set; }=DateTime.Now.ToString("yyyyMMddhhmmss");

        [Display(Name ="Tên Thuốc")]
        [Required(ErrorMessage ="phải nhập {0}")]
        [StringLength(50,ErrorMessage ="{0} phải từ {2} đến {1} ký tự",MinimumLength =3)]
        public string Name { get; set; }

        [Display(Name ="Mô tả")]
        [StringLength(150,ErrorMessage ="{0} phải từ {2} đến {1} ký tự",MinimumLength =3)]
        public string Description { get; set; }

        public List<MedicinesCategory> MedicinesCatogorys{get;set;}

        public int? UnitID{get;set;}
        [ForeignKey("UnitID")]
        public Unit Units{get;set;}

        [Display(Name ="Đơn giá")]
        [DisplayFormat(DataFormatString ="{0:0.000}",ApplyFormatInEditMode =true)]
        
        public decimal? UnitPrice{get;set;}

        [Display(Name ="Giá bán")]
        [DisplayFormat(DataFormatString ="{0:0.000}",ApplyFormatInEditMode =true)]
        public decimal? SellPrice{get;set;}      
        [Display(Name ="Số lượng")]
        public int Quantity{get;set;}

        [Display(Name ="Ngày Hết hạn")]
        public DateTime? ExpiryDate{get;set;}


          [Display(Name ="Đơn giá cũ")]
        [DisplayFormat(DataFormatString ="{0:0.000}",ApplyFormatInEditMode =true)]
        
        public decimal? OldUnitPrice{get;set;}

        [Display(Name ="Giá bán cũ")]
        [DisplayFormat(DataFormatString ="{0:0.000}",ApplyFormatInEditMode =true)]
        public decimal? OldSellPrice{get;set;}    


         [Display(Name ="Ngày tạo")]
        public DateTime? DateCreate{get;set;}  

        
         [Display(Name ="Ngày Cập Nhật")]
        public DateTime? DateModify{get;set;}  

        public string UserID{get;set;}
       

        public string UserIDModify{get;set;}
       

    }
}