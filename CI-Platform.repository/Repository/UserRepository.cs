using CI_Platform.entites.Data;
using CI_Platform.entites.Models;
using CI_Platform.repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_Platform.repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CiPlatformContext _CiPlatformContext;
        public UserRepository(CiPlatformContext ciPlatformContext)
        {
            _CiPlatformContext = ciPlatformContext;
        }
        public List<User> GetUsersList()
        {
            List<User> Lstusers = _CiPlatformContext.Users.ToList();
            return Lstusers;
        }
        //public void InsertUser(User user)
        //{
        //    _ciPlatformContext.Users.Add(user);
        //    _ciPlatformContext.SaveChanges();
        //}
        public User Add(User user)
        {
            var adduser = _CiPlatformContext.Set<User>().Add(user);
            Savechanges();
            return adduser.Entity;
            throw new NotImplementedException();
        }

        private void Savechanges()
        {
            throw new NotImplementedException();
        }

        void IUserRepository.Add(User user)
        {
            throw new NotImplementedException();
        }

        void IUserRepository.Savechanges()
        {
            throw new NotImplementedException();
        }
                
        public void InsertUser(User user)
        {
            throw new NotImplementedException();
        }
    }

}

