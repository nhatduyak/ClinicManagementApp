using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

         [Display(Name ="Tên Danh Mục")]
        [Required(ErrorMessage ="phải nhập {0}")]
        [StringLength(100,ErrorMessage ="{0} phải từ {2} đến {1} ký tự",MinimumLength =3)]
        public string Name { get; set; }

        [Display(Name ="Mô tả")]
        public string Descriptions { get; set; }

        public int ParentCategoryID { get; set; }

        [ForeignKey("ParentCategoryID")]
        public Category ParentCategory{get;set;}
    }
}