﻿using DataAccessDefinitionLibrary.DAO_Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.DTOs.Converters;

namespace QuizBytesAPIServer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private IWebUserDataAccess WebUserDataAccess { get; set; }
        public AccountController(IWebUserDataAccess webUserDataAccess)
        {
            WebUserDataAccess = webUserDataAccess;
        }

        [HttpPost]
        public async Task<ActionResult<WebUserDto>> LoginUserAsync([FromBody]WebUserDto webUser)
        {
            if(webUser == null)
            {
                return NotFound();
            }
            var user = await WebUserDataAccess.LoginAsync(webUser.Username, webUser.PasswordHash);
            return Ok(user.ToDto());

        }
    }
}
