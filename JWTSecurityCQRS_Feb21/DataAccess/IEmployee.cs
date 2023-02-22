using JWTSecurityCQRS_Feb21.Models;

namespace JWTSecurityCQRS_Feb21.DataAccess
{
    public interface IEmployee
    {
        List<Temployee> Create(Temployee employee); 
        List<Temployee> Update(Temployee employee);
        List<Temployee> GetEmployees();
        public string Delete(int id); 
        //public string GetEmployeeNameById(int id);
        //public Temployee employeeGetEmployeeById(int id);  

    }
}
