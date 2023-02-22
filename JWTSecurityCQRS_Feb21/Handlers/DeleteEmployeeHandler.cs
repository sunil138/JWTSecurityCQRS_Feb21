using JWTSecurityCQRS_Feb21.Commands;
using JWTSecurityCQRS_Feb21.DataAccess;
using MediatR;

namespace JWTSecurityCQRS_Feb21.Handlers
{
    public class DeleteEmployeeHandler:IRequestHandler<DeleteEmployeeCommand,string>
    {
        private readonly IEmployee _employee;
        public DeleteEmployeeHandler(IEmployee employee)
        {
            _employee = employee;
        }

        public async Task<string> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_employee.Delete(request.id)); 
        }
    }
}
