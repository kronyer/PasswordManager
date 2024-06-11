using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Areas.Identity.Data;
using PasswordManager.Data;
using PasswordManager.Models;
using PasswordManager.Utility;
using System.Security.Claims;

namespace PasswordManager.Controllers
{
    [Authorize]
    public class PasswordController : Controller
    {
        private readonly PasswordManagerContext _db;
        private readonly UserManager<PasswordManagerUser> _userManager;

        public PasswordController(PasswordManagerContext db, UserManager<PasswordManagerUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string? search)
        {
            var userId = _userManager.GetUserId(User);
            
            var user = await _userManager.FindByIdAsync(userId);
            if (!string.IsNullOrEmpty(search))
            {
                

                List<Password> filteredPasswords = _db.Passwords.Where(x => x.UserId == userId && x.Website.Contains(search)).ToList();
                foreach (var password in filteredPasswords)
                {
                    password.DecryptedPassword = PasswordEncryptor.DecryptPassword(password.PasswordValue, user.EncryptionKey);
                }
                return View(filteredPasswords);
            }
            

           List<Password> userPasswords =  _db.Passwords.Where(x => x.UserId == userId).ToList();
            foreach (var password in userPasswords)
            {
                password.DecryptedPassword = PasswordEncryptor.DecryptPassword(password.PasswordValue, user.EncryptionKey);
            }
            return View(userPasswords);
        }

        public async Task<IActionResult> UpsertAsync(int? id)
        {
            Password model;
            if (id == null || id == 0)
            {
                model = new Password();
            }
            else
            {
                model = await _db.Passwords.FindAsync(id);
                if (model == null)
                {
                    return NotFound();
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpsertAsync(Password model)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            model.UserId = userId;

            var user = await _userManager.FindByIdAsync(userId);
            var userKey = user.EncryptionKey;

            if (ModelState.IsValid)
            {
                model.PasswordValue = PasswordEncryptor.EncryptPassword(model.PasswordValue, userKey);

                if (model.Id == 0)
                {
                    _db.Passwords.Add(model);
                }
                else
                {
                    _db.Passwords.Update(model);
                }

                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult GeneratePassword(int length, bool upperCase, bool numbers, bool specials)
        {
            var password = PasswordGenerator.GeneratePassword(length, upperCase, numbers, specials);
            return Json(password);
        }
    }
}
