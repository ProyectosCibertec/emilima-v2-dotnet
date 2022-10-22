using System.ComponentModel.DataAnnotations;

namespace EmilimaV2Web.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(45)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Recuérdame")]
        public bool RememberMe { get; set; }
    }
}
