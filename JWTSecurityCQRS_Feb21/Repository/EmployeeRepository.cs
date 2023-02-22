using JWTSecurityCQRS_Feb21.DataAccess;
using JWTSecurityCQRS_Feb21.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTSecurityCQRS_Feb21.Repository
{
    public class EmployeeRepository:IEmployee
    {
        private readonly EmployeeDBContext _context;
        public EmployeeRepository(EmployeeDBContext context)
        {
            _context = context;
        }

        public List<Temployee> Create(Temployee employee)
        {
            _context.Temployees.Add(employee);
            _context.SaveChanges();
            return _context.Temployees.ToList(); 
        }

        public string Delete(int id)
        {
            var delId = _context.Temployees.Find(id);
            if(delId != null)
            {
                _context.Temployees.Remove(delId);
                _context.SaveChanges();
                return "Successful";
            }
            else
            {
                return "EmployeeId not found";
            }
        }

        //public async Task<Temployee> employeeGetEmployeeById(int id)
        //{
        //    var result=await _context.Temployees.FirstOrDefaultAsync(b=>b.Equals(id));
        //    return result;  
        //}

        //public async Task<string> GetEmployeeNameById(int id)
        //{
        //    var mn=await _context.Temployees.Where(a=>a.Equals(id)).Select(d=>d.EmployeeName).FirstOrDefaultAsync();
        //    return mn;   
        //} 

        public List<Temployee> GetEmployees()
        {
            return _context.Temployees.ToList();
        }

        public List<Temployee> Update(Temployee employee)
        {
            var upId = _context.Temployees.Find(employee.EmployeeId);
            if(upId != null)
            {
                upId.EmployeeId=employee.EmployeeId;
                upId.EmployeeName=employee.EmployeeName;
                upId.EmployeeSalary = employee.EmployeeSalary;
            }
            _context.SaveChanges();
            return _context.Temployees.ToList(); 
        }

        //Temployee IEmployee.employeeGetEmployeeById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //string IEmployee.GetEmployeeNameById(int id)
        //{
        //    throw new NotImplementedException();
        //} 
    }
}
