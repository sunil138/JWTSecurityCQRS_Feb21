using JWTSecurityCQRS_Feb21.Queries;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTSecurityCQRS_Feb21.Controllers
{
    [EnableCors("swagger")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("getAllEmployees")] 
        public async Task<ActionResult>GetAllEmployees()
        {
            var employeest = await _mediator.Send(new GetEmployeeQuery());
            return Ok(employeest); 
        }
    }
}
