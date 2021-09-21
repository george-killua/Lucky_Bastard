using Data_Access.Enum;
using Data_Access.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Access.DBContext
{
    public class UserManger : IUserManger
    {
        private readonly MyDBContext _context;

        public UserManger(MyDBContext dBContext)
        {
            _context = dBContext;
        }

        public async Task<string> AddUser(User user)
        {
            _context.Users.Add(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.Username))
                {
                    return "User Exist!";
                }
                else
                {
                    throw;
                }
            }

            return "User !!Added!!";
        }

        public async Task<string> DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return "User NOT Exist!";
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return "User !!Deleted!!";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public async Task<User> FindByNameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
                return null;


            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<IEnumerable<User>> GetAllUsersCreater(string username)
        {

            IEnumerable<User> user = await _context.Users.Where(x => x.Creater == username).ToListAsync();
            if (user == null)
                return null;


            return user;

        }
        public async Task<IEnumerable<User>> GetAllUsersType(UserType type)
        {

            IEnumerable<User> user = await _context.Users.Where(x => x.UserType == type).ToListAsync();
            if (user == null)
                return null;


            return user;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public async Task<string> UpdateAsync(User user)
        {


            _context.Entry(user).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
                return "User !!Updated!!";

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Username))
                {
                    return "User NOT Exist!";
                }
                else
                {
                    throw;
                }
            }


        }


        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Username == id);
        }
    }
}