using JWTSecurityCQRS_Feb21.Models;
using MediatR;

namespace JWTSecurityCQRS_Feb21.Queries
{
    public record GetEmployeeQuery:IRequest<List<Temployee>>; 
   
}
