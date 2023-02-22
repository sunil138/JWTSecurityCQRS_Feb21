using JWTSecurityCQRS_Feb21.Commands;
using JWTSecurityCQRS_Feb21.Models;
using JWTSecurityCQRS_Feb21.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTSecurityCQRS_Feb21.Controllers
{
    [EnableCors("swagger")] 
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")] 
    public class AdminController : ControllerBase 
    {
        private readonly IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("getEmployees")]
        public async Task<ActionResult>GetEmployee()
        {
            var employees = await _mediator.Send(new GetEmployeeQuery());
            return Ok(employees); 
        }
        [HttpPost]
        [Route("addEmployee")]
        public async Task<ActionResult> AddEmployees([FromBody]Temployee employee)
        {
            await _mediator.Send(new AddEmployeeCommand(employee));
            return StatusCode(201);
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<ActionResult> UpdateEmployees([FromBody]Temployee employee)
        {
            await _mediator.Send(new UpdateEmployeeCommand(employee));
            return StatusCode(201);
        }
        [HttpDelete]
        [Route("id")] 
        public async Task<ActionResult>DeleteEmployee(int id)
        {
            await _mediator.Send(new DeleteEmployeeCommand(id));
            return StatusCode(200); 
        }

        //[HttpGet]
        //[Route("getEmployeeById/{id}")]
        //public async Task<ActionResult>GetEmployeeById(int id)
        //{
        //    var employeeId = await _mediator.Send(new GetEmployeeIdQuery(id));
        //    return Ok(employeeId); 
        //}

        //[HttpGet]
        //[Route("getEmployeeNameById/{id}")] 
        //public async Task<ActionResult>GetEmployeeNameById(int id)
        //{
        //    var employeeName = await _mediator.Send(new GetEmployeeNameByIdQuery(id));
        //    return Ok(employeeName); 
        //} 
    }
}
