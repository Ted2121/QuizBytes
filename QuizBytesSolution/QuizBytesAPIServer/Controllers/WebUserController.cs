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
    private IWebUserDataAccess WebUserDataAccess { get; set; }

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
        if(!await WebUserDataAccess.UpdateWebUserAsync(webUser.FromDto()))
        {
            return NotFound();
        }
        return Ok();
    }

    [HttpPut]
    [Route("password")]
    public async Task<ActionResult> UpdatePasswordAsync(WebUserDto webUser)
    {
        if (!await WebUserDataAccess.UpdatePasswordAsync(webUser.Username, webUser.Password, webUser.NewPassword))
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<WebUserDto>> GetWebUserByIdAsync([FromQuery] int id)
    {
        var user = await WebUserDataAccess.GetWebUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }
        return Ok();

    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteWebUserAsync([FromQuery] int id)
    {
        if(!await WebUserDataAccess.DeleteWebUserAsync(id))
        {
            return BadRequest();

        }

        return Ok();
    }


}


