using CapitecDashboard.Domain.Interfaces.Services.QueryService;
using CapitecDashboard.Domain.Models.Request;
using CapitecDashboard.Domain.Models.Request.Filters;
using CapitecDashboard.Domain.Services.CommandServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitecDashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessLevelController : ControllerBase
    {
        private readonly IAccessLevelCommandService accessLevelCommandService;
        private readonly IAccessLevelQueryService accessLevelQueryService;

        public AccessLevelController(IAccessLevelCommandService accessLevelCommandService,
          IAccessLevelQueryService accessLevelQueryService)
        {
            this.accessLevelCommandService = accessLevelCommandService;
            this.accessLevelQueryService = accessLevelQueryService;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] AccessLevelRequest request)
        {
            var res = accessLevelCommandService.Add(request);
            return Ok(res);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] BaseRequest request)
        {
            var res = accessLevelCommandService.Delete(request);
            return Ok(res);
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] AccessLevelRequest request)
        {
            var res = accessLevelCommandService.Edit(request);
            return Ok(res);
        }

        [HttpGet("filter")]
        public IActionResult GetByFilter([FromQuery] AccessLevelFilter filter)
        {
            var response = accessLevelQueryService.Filter(filter);
            return Ok(response);
        }

        [HttpGet("get-by-uid")]
        public IActionResult FilterByUID(string uid)
        {
            var response = accessLevelQueryService.Get(uid);
            return Ok(response);
        }

    }
}
