using DataAccessDefinitionLibrary.DAO_Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuizBytesAPIServer.DTOs;
using QuizBytesAPIServer.DTOs.Converters;
using SQLAccessImplementationLibrary;

namespace QuizBytesAPIServer.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class WebUserController : ControllerBase
{
    public IWebUserDataAccess WebUserDataAccess { get; set; }

    public WebUserController(IWebUserDataAccess webUserDataAccess)
    {
        WebUserDataAccess = webUserDataAccess;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WebUserDto>>> GetAllWebUsersAsync()
    {
        var webUsers = await WebUserDataAccess.GetAllWebUsersAsync();

        if(webUsers == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(webUsers.ToDtos());
        }
        
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateWebUserAsync(WebUserDto webUser)
    {
        return Ok(await WebUserDataAccess.InsertWebUserAsync(webUser.FromDto()));
    }

    [HttpGet]
    [Route("Username")]
    public async Task<ActionResult<WebUserDto>> GetWebUserByUsernameAsync(string username)
    {
        var webUser = await WebUserDataAccess.GetWebUserByUsernameAsync(username);

        if(webUser == null)
        {
            return NotFound();

        }
        else
        {
            return Ok(webUser.ToDto());
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateWebUserAsync(WebUserDto webUser)
    {

    }

    [HttpPut]
    [Route("password")]
    public async Task<ActionResult> UpdatePasswordAsync(WebUserDto webUser)
    {

    }
}


