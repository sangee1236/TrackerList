using System.Collections.Generic;
using TrackerList.Model;

namespace TrackerList.Data.Model
{
    public interface IUserModel
    {
        bool AddUser(Users Group);
        bool UpdateUser(Users Group);
        bool DeleteUser(int Id);
        IEnumerable<Users> GetAllUser();
        IEnumerable<Users> GetUserById(int Id);
        Users OnLogin(string emailID, string password);
    }
}
