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

}


