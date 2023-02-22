using JWTSecurityCQRS_Feb21.Models;
using MediatR;

namespace JWTSecurityCQRS_Feb21.Commands
{
    public record UpdateEmployeeCommand(Temployee employee):IRequest<List<Temployee>>;
   
}
