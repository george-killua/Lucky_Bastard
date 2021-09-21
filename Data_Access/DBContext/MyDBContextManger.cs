using Data_Access.Enum;
using Data_Access.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

namespace Data_Access.DBContext
{
    public class MyDBContextManger<T> where T : class
    {
        internal readonly MyDBContext _context;

        public MyDBContextManger (MyDBContext dBContext)
        {
            _context = dBContext;
        }
        public virtual async Task<IEnumerable<T>> ListAsync()
        {
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public virtual async Task<T> FindByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    

    public async Task<int> AddChargeHistory(ChargeHistory tChargeHistory)
        {
            _context.ChargeHistories.Add(tChargeHistory);


            var res = await _context.SaveChangesAsync();



            return res;
        }
        public async Task<int> AddloginHistory(LoginHistory loginHistory)
        {
            _ = await _context.LoginHistories.AddAsync(loginHistory);


            int res;
            try
            {
                res = await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                var error = e.Message;
                if (error != null)
                {
                    //return the error string
                }
                throw; //couldn’t handle that error, so rethrow
            }

            return res;
        }

    
    }
}