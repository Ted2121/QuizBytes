using DataAccessDefinitionLibrary.DAO_Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuizBytesAPIServer.DTOs;

namespace QuizBytesAPIServer.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LoginController : ControllerBase
{
    private IWebUserDataAccess WebUserDataAccess { get; set; }
    public LoginController(IWebUserDataAccess webUserDataAccess)
    {
        WebUserDataAccess = webUserDataAccess;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] WebUserDto webUser) =>
            await WebUserDataAccess.LoginAsync(webUser.Username, webUser.PasswordHash);
}
