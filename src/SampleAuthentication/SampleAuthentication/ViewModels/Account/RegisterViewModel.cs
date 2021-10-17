using System.ComponentModel.DataAnnotations;

namespace SampleAuthentication.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Display(Name = "お名前")]
        [Required]
        public string DispName
        {
            get;
            set;
        }

        [Display(Name = "メールドレス")]
        [Required]
        [EmailAddress]
        public string Email
        {
            get;
            set;
        }

        [Display(Name = "パスワード")]
        [Required]
        [DataType(DataType.Password)]
        public string Pwd
        {
            get;
            set;
        }
    }
}
