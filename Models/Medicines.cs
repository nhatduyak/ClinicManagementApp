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

        public virtual List<MedicinesCategory> MedicinesCatogorys{get;set;}

        [Display(Name ="Đơn vị tính")]
        public int? UnitID{get;set;}
        [ForeignKey("UnitID")]
        public virtual Unit Units{get;set;}

         [Display(Name ="Nhà sản xuất")]
        public int? ManufactureId{get;set;}
        [ForeignKey("ManufactureId")]
        public virtual Manufacture Manufacture{get;set;}

        [Display(Name ="Đơn giá")]
        [Column(TypeName ="smallmoney")]
        [DisplayFormat(DataFormatString ="{0:0.000}",ApplyFormatInEditMode =true)]
        
        public decimal? UnitPrice{get;set;}

        [Display(Name ="Giá bán")]
        [Column(TypeName ="smallmoney")]
        [DisplayFormat(DataFormatString ="{0:0.000}",ApplyFormatInEditMode =true)]
        public decimal? SellPrice{get;set;}      
        [Display(Name ="Số lượng")]
        public int Quantity{get;set;}

        [Display(Name ="Ngày Hết hạn")]
        public DateTime? ExpiryDate{get;set;}=DateTime.Now;


          [Display(Name ="Đơn giá cũ")]
        [DisplayFormat(DataFormatString ="{0:0.000}",ApplyFormatInEditMode =true)]
        [Column(TypeName ="smallmoney")]
        public decimal? OldUnitPrice{get;set;}

        [Display(Name ="Giá bán cũ")]
        [Column(TypeName ="smallmoney")]
        [DisplayFormat(DataFormatString ="{0:0.000}",ApplyFormatInEditMode =true)]
        public decimal? OldSellPrice{get;set;}    


         [Display(Name ="Ngày tạo")]
        public DateTime? DateCreate{get;set;} =DateTime.Now;

        
         [Display(Name ="Ngày Cập Nhật")]
        public DateTime? DateModify{get;set;} =null;

        public string UserID{get;set;}
        // [ForeignKey("UserCreate")]
        // [NotMapped]
        // public AppUser UserCreate{get;set;}
       

        public string UserIDModify{get;set;}
        //  [ForeignKey("UserModify")]
        //  [NotMapped]
        // public AppUser UserModify{get;set;}

    }
}