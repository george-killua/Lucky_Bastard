using Data_Access.Enum;
using Data_Access.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access.DBContext
{
    public interface IUserManger
    {
        Task<string> AddUser(User user);
        Task<string> DeleteUser(string id);
        Task<User> FindByNameAsync(string username);
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetAllUsersCreater(string username);
        Task<IEnumerable<User>> GetAllUsersType(UserType type);
        Task<string> UpdateAsync(User user);
    }
}