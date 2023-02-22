using JWTSecurityCQRS_Feb21.DataAccess;
using JWTSecurityCQRS_Feb21.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTSecurityCQRS_Feb21.Repository
{
    public class UserRepository : IUser
    {
        private readonly EmployeeDBContext _context;
        public UserRepository(EmployeeDBContext context)
        {
            _context = context; 
        }

        public List<Tuser> CreateUser(Tuser user)
        {
            _context.Tusers.Add(user);
            _context.SaveChanges();
            return _context.Tusers.ToList();
        }

        public string DeleteUser(int id)
        {
            var dId = _context.Tusers.Find(id);
            if (dId != null)
            {
                _context.Tusers.Remove(dId);
                _context.SaveChanges();
                return "Success";
            }
            else
            {
                return "UserId not found";
            }
        }

        public List<Tuser> GetUsers()
        {
            return _context.Tusers.ToList();
        }

        public List<Tuser> UpdateUser(Tuser user)
        {
            var uId = _context.Tusers.Find(user.Id);
            if (uId != null)
            {
                uId.Id = user.Id;
                uId.UserId = user.UserId;
                uId.Password = user.Password;
                uId.Role = user.Role;
            }
            _context.SaveChanges();
            return _context.Tusers.ToList();
        }

    }
}
