using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.ViewModels
{
    public class LoginViewModel
    {
        [DisplayName("Tên đăng nhập")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Nhập tên đăng nhập")]
        [RegularExpression(@"^[a-zA-Z0-9]*$" ,ErrorMessage = "Tên đăng nhập không đúng định dạng")]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "* Tên đăng nhập có tối thiểu 3 kí tự và tối đa 16 kí tự.")]
        public string UserName { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Nhập mật khẩu")]
        [MinLength(3, ErrorMessage = "* Mật khẩu có tối thiểu 6 kí tự ")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Tên đăng nhập không đúng định dạng")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
    }
}
