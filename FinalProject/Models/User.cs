using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserID { get; set; }

        [Display(Name = "Login", ResourceType = typeof(Resources.Localization))]
        [Required(ErrorMessageResourceName = "ErrorLogin", ErrorMessageResourceType = typeof(Resources.Localization))]
        public string Login { get; set; }

        [MinLength(6, ErrorMessage = "Hasło musi się składać z min 6 znaków")]
        [Display(Name = "Password", ResourceType = typeof(Resources.Localization))]
        [Required(ErrorMessageResourceName = "ErrorPassword", ErrorMessageResourceType = typeof(Resources.Localization))]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public bool Active { get; set; }

        [Required]
        public int AccountType { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resources.Localization))]
        [Required(ErrorMessageResourceName = "ErrorEmail", ErrorMessageResourceType = typeof(Resources.Localization))]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}