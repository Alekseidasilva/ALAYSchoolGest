using Microsoft.AspNetCore.Mvc;

namespace ALAYSchoolGest.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Variables
        #endregion

        #region Contruts
        #endregion

        #region Methods
        [HttpGet("v1/users")]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
        #endregion

    }
}
