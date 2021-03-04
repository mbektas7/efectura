using Efectura.DBContext;
using Efectura.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Efectura.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _dbContext;

        public UserRepository(UserContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteUser(string TCKN)
        {
            var User = _dbContext.Users.Find(TCKN);
            if (User!=null)
            {
                _dbContext.Users.Remove(User);
                Save();
            }
           else
                throw new ArgumentNullException(nameof(User));
        }

        public User GetUserByTCKN(string TCKN)
        {
            return _dbContext.Users.Find(TCKN);
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void InsertUser(User User)
        {
            if (User == null)
            {
                throw new ArgumentNullException(nameof(User));
            }
            _dbContext.Add(User);
            Save();
        }

        public void Save()
        {

            _dbContext.SaveChanges();
        }

        public void UpdateUser(User User)
        {
            _dbContext.Entry(User).State = EntityState.Modified;
            Save();
        }
    }
}
