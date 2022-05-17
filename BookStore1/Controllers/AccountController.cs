using Microsoft.AspNetCore.Mvc;
using BookStore1.Data;
using BookStore1.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using BookStore1.Models.Repositories.Interfaces;

namespace BookStore1.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public const string COOKIE = "CookieAuth";
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpGet]
        public IActionResult Reigster()
        {
            return View();
        }
        public IActionResult Reigster(Account account)
        {
            if (ModelState.IsValid)
            {
                _accountRepository.AddAccount(account);
                return RedirectToAction("Success");
            }
            return View(account);
        }

        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string UserName, string Password)
        {
            var _account = _accountRepository.GetAccount(UserName, Password);
            if (_account != null)
            {
                List<Claim> claims = new()
                {
                    new Claim("AccountType", _account.AccountType),
                    new Claim(ClaimTypes.Name, _account.UserName),
                };
                ClaimsIdentity identity = new(claims, COOKIE);
                ClaimsPrincipal claimPricipal = new(identity);
                await HttpContext.SignInAsync(COOKIE, claimPricipal);
                if (_account.AccountType == "Admin")
                {
                    return RedirectToAction("AdminMainPage", "Admin");
                }
                return RedirectToAction("HomeView", "Home");
            }
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(COOKIE);
            return RedirectToAction("HomeView", "Home");
        }
    }
}
