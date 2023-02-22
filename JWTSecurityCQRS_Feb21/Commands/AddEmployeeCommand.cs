using JWTSecurityCQRS_Feb21.Models;
using MediatR;

namespace JWTSecurityCQRS_Feb21.Commands
{
    public record AddEmployeeCommand(Temployee employee):IRequest<List<Temployee>>; 
    
}
