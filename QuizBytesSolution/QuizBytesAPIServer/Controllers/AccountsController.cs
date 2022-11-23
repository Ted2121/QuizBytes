using DataAccessDefinitionLibrary.DAO_Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.DTOs.Converters;

namespace QuizBytesAPIServer.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AccountsController : ControllerBase
{
    private IWebUserDataAccess WebUserDataAccess { get; set; }
    public AccountsController(IWebUserDataAccess webUserDataAccess)
    {
        WebUserDataAccess = webUserDataAccess;
    }

    [HttpPost]
    public async Task<ActionResult<WebUserDto>> LoginAsync(WebUserDto webUser)
    {
            var user = await WebUserDataAccess.LoginAsync(webUser.Username, webUser.PasswordHash);
        return Ok(user.ToDto());

    }
}
