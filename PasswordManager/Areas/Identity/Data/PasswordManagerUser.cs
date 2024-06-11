using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PasswordManager.Models;

namespace PasswordManager.Areas.Identity.Data;

// Add profile data for application users by adding properties to the PasswordManagerUser class
public class PasswordManagerUser : IdentityUser
{
    public ICollection<Password> Passwords { get; set; }
    public byte[] EncryptionKey { get; set; } 

}

