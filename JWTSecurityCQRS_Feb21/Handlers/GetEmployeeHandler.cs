using JWTSecurityCQRS_Feb21.DataAccess;
using JWTSecurityCQRS_Feb21.Models;
using JWTSecurityCQRS_Feb21.Queries;
using MediatR;

namespace JWTSecurityCQRS_Feb21.Handlers
{
    public class GetEmployeeHandler:IRequestHandler<GetEmployeeQuery,List<Temployee>>
    {
        private readonly IEmployee _employee;
        public GetEmployeeHandler(IEmployee employee)
        {
            _employee = employee;
        }

        public async Task<List<Temployee>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_employee.GetEmployees()); 
        }
    }
}
