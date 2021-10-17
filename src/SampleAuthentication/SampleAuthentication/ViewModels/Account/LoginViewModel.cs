using System.ComponentModel.DataAnnotations;

namespace SampleAuthentication.ViewModels.Account
{
    public class LoginViewModel
    {
        [Display(Name = "メールドレス")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "パスワード")]
        [Required]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }

        [Display(Name = "ログイン状態の保持")]
        public bool RememberMe { get; set; }
    }
}
