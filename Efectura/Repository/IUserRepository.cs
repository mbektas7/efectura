using Efectura.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Efectura.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();

        User GetUserByTCKN(string TCKN);

        void InsertUser(User User);

        void DeleteUser(string TCKN);
        void UpdateUser(User User);
        void Save();
    }
}
