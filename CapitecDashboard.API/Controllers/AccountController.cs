using CapitecDashboard.Domain.Interfaces;
using CapitecDashboard.Domain.Models.Request;
using CapitecDashboard.Domain.Models.Request.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitecDashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticateService authenticateService;
       // private readonly IUserFacilityQueryService userFacilityQueryService;
        public AccountController(IAuthenticateService authenticateService)
           // IUserFacilityQueryService userFacilityQueryService)
        {
            this.authenticateService = authenticateService;
            //this.userFacilityQueryService = userFacilityQueryService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var res = await authenticateService.Login(request);
            return Ok(res);
        }

        [HttpPost("create-account")]
        public async Task<IActionResult> CreateAccount([FromBody] UserRequest request)
        {
            var res = await authenticateService.Register(request);
            return Ok(res);
        }


        [HttpGet("filter")]
        public IActionResult Filter([FromQuery] UserFilter request)
        {
            var res = authenticateService.Filter(request);
            return Ok(res);
        }

        [HttpPost("create-role")]
        public async Task<IActionResult> AddRole([FromBody] RoleRequest request)
        {
            var res = await authenticateService.CreateNewRole(request);
            return Ok(res);
        }

        [HttpPost("add-user-role")]
        public async Task<IActionResult> AddUserToRole([FromBody] RoleAddRequest request)
        {
            var res = await authenticateService.AddUserToRole(request);
            return Ok(res);
        }

        [HttpPost("remove-role")]
        public async Task<IActionResult> RemoveRole([FromBody] RoleDeleteRequest request)
        {
            var res = await authenticateService.RemoveUserRole(request);
            return Ok(res);
        }

       

        [HttpPost("assign-user-to-facility")]
        public IActionResult AssignUserToFacility([FromBody] UserFacilityRequest request)
        {
            var res = authenticateService.AssignUserToFacility(request);
            return Ok(res);
        }

        [HttpPost("save-user-detail")]
        public IActionResult SaveUserDetail([FromBody] UserDetailRequest request)
        {
            var res = authenticateService.SaveUserDetail(request);
            return Ok(res);
        }
    }
}
