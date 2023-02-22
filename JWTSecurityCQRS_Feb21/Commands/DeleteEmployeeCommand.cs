using MediatR;

namespace JWTSecurityCQRS_Feb21.Commands
{
    public record DeleteEmployeeCommand(int id):IRequest<string>; 
   
}
