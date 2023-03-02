using CI_Platform.Entities.Data;
using CI_Platform.Entities.Models;
using CI_Platform.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_Platform.Repository.Repositories
{ 
    public class UserRepository : IUserRepository
    {
        public readonly CiplatformContext _CiplatformDbContext;
        
        public UserRepository(CiplatformContext ciplatformDbContext)
        {
            _CiplatformDbContext = ciplatformDbContext;
        }
        public List<User> GetUserData()
        {
            List<User> users = _CiplatformDbContext.Users.ToList();
            return users;
        }
        public void Registration(User objreg)
        {
            _CiplatformDbContext.Users.Add(objreg);
            _CiplatformDbContext.SaveChanges();
        }
        


    }
}
