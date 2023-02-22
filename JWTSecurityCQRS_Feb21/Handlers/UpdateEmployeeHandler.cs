using JWTSecurityCQRS_Feb21.Commands;
using JWTSecurityCQRS_Feb21.DataAccess;
using JWTSecurityCQRS_Feb21.Models;
using MediatR;

namespace JWTSecurityCQRS_Feb21.Handlers
{
    public class UpdateEmployeeHandler:IRequestHandler<UpdateEmployeeCommand,List<Temployee>>
    {
        private readonly IEmployee _employee;
        public UpdateEmployeeHandler(IEmployee employee)
        {
            _employee = employee;
        }

        public async Task<List<Temployee>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_employee.Update(request.employee)); 
        }
    }
}
