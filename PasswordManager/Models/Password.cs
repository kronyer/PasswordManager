using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PasswordManager.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasswordManager.Models
{
    public class Password
    {
        public int Id { get; set; }
        public string Website { get; set; }
        public string Login { get; set; }
        [Display(Name = "Password")]
        public string PasswordValue { get; set; }
        [NotMapped]
        [ValidateNever]
        public string DecryptedPassword { get; set; }
        [ValidateNever]
        public string Salt { get; set; }
        [ValidateNever]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public PasswordManagerUser User { get; set; }
        [ValidateNever]
        public byte[]  PasswordIV { get; set; }
    }
}
