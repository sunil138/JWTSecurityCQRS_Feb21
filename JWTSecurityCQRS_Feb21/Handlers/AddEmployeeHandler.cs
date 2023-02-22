using JWTSecurityCQRS_Feb21.Commands;
using JWTSecurityCQRS_Feb21.DataAccess;
using JWTSecurityCQRS_Feb21.Models;
using MediatR;

namespace JWTSecurityCQRS_Feb21.Handlers
{
    public class AddEmployeeHandler:IRequestHandler<AddEmployeeCommand,List<Temployee>>
    {
        private readonly IEmployee _employee;
        public AddEmployeeHandler(IEmployee employee)
        {
            _employee = employee;
        }

        public async Task<List<Temployee>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_employee.Create(request.employee));
        }
    }
}
