using JWTSecurityCQRS_Feb21.Models;

namespace JWTSecurityCQRS_Feb21.DataAccess
{
    public interface IUser
    {
        List<Tuser> CreateUser(Tuser user);
        List<Tuser> UpdateUser(Tuser user);
        List<Tuser> GetUsers();
        public string DeleteUser(int id);
        //public Tuser LoginUser(Tuser user);  
    }
}
