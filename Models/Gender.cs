using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Models
{
    public class Gender
    {
        [Key]
        public int ID { get; set; }

        [Display(Name ="Giới tính")]
        [Required(ErrorMessage ="phải nhập {0}")]
        [StringLength(20,ErrorMessage ="{0} phải từ {2} đến {1} ký tự",MinimumLength =1)]
        public string Name { get; set; }
    }


}