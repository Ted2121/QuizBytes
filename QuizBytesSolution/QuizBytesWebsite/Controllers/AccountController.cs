﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApiClient;
using WebApiClient.DTOs;

namespace QuizBytesWebsite.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IWebUserFacadeApiClient WebUserFacadeApiClient { get; set; }

        public AccountController(IWebUserFacadeApiClient webUserFacadeApiClient)
        {
            WebUserFacadeApiClient = webUserFacadeApiClient;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] WebUserDto loginInfo, [FromQuery] string? returnUrl)
        {
            var user = await WebUserFacadeApiClient.LoginUserAsync(loginInfo);

            if (user != null)
            {
                var claims = new List<Claim>
                    {
                        new Claim("id", user.Id.ToString()),
                        new Claim("username", user.Username)
                    };

                await SignInUsingClaims(claims);
            }
            else
            {
                ViewBag.ErrorMessage = "Incorrect Login";
            }

            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        private async Task SignInUsingClaims(List<Claim> claims)
        {
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30),
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
        
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["Message"] = "You are now logged out.";
            return RedirectToAction("Index", "");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(WebUserDto webUser)
        {
            ModelState.Remove("NewPassword");
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Failed to register your account - please try again later!";
            }
            else
            {
                try
                {
                    if (await WebUserFacadeApiClient.CreateWebUserAsync(webUser) > 0)
                    {
                        TempData["Message"] = $"Welcome, {webUser.Username}! Enjoy quizzing on our website.";
                        return RedirectToAction(nameof(Index), "Home");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Failed to register your account - please try again later!";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                }
            }
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            WebUserDto user = null;
            var userIdFromClaim = HttpContext.User.Claims.FirstOrDefault((claim) => claim.Type == "id")?.Value;
            int userId;
            bool success = int.TryParse(userIdFromClaim, out userId);

            if (success)
            {
            user = await WebUserFacadeApiClient.GetWebUserByIdAsync(userId);
            }
            else
            {
                ViewBag.ErrorMessage = "Failed to find your profile - please try again later!";
            }
            return View(user);
        }
    }
}
