using System.ComponentModel.DataAnnotations;

namespace shop.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Bạn phải nhập tên tài khoản !")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu !"), DataType(DataType.Password)]
        public string Password { get ;set; }

        public string ReturnUrl { get ;set; }

        [Display(Name = "Remember Me ?")]
        public bool RememberMe { get ;set; }
    }
}