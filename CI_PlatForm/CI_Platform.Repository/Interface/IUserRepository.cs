﻿
using CI_Platform.Entities.Models;
using CI_Platform.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_Platform.Repository.Interface
{
    public interface IUserRepository
    {
        public List<User> UserList();
        //public void Registration(User objacc);

        public Boolean IsEmailAvailable(string email);

        public User IsPasswordAvailable(string password, string email);

        public long GetUserID(string Email);

        public bool ResetPassword(long userId, string OldPassword, string NewPassword);

        public Boolean ChangePassword(long UserId, Reset_Password model);

        /*public void FP(User objreset);*/
        /*public string Authenticate(string Email);*/
    }

}
