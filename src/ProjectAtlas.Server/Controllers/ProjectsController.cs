using Microsoft.AspNetCore.Mvc;
using ProjectAtlas.Shared.DTOs;

namespace ProjectAtlas.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {




        [HttpGet("Get")]
        public ActionResult<TextDto> GetString()
        {
            return Ok(new TextDto
            {
                Text = "Funguje To!!!",
                SendTime = DateTime.UtcNow 
            });

        }





    }





}
