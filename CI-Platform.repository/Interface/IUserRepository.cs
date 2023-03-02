using CI_Platform.entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_Platform.repository.Interface
{
    public interface IUserRepository
    {
        public List<User> GetUsersList();

        public void Add(User user);
        void Savechanges();
        void InsertUser(User user);
    }
}
