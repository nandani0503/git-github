using CI_Platform.Entities.Data;
using CI_Platform.Entities.Models;
using CI_Platform.Entities.ViewModel;
using CI_Platform.Repository.Interface;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CI_Platform.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly CiplatformContext _CiplatformDbContext;
        /*private readonly string pwd;*/

        public UserRepository(CiplatformContext ciplatformDbContext/*, string pwd*/)
        {
            _CiplatformDbContext = ciplatformDbContext;
            /* this.pwd = pwd;*/
        }
        public List<User> UserList()
        {
            List<User> objUserList = _CiplatformDbContext.Users.ToList();
            return objUserList;
        }

        public Boolean IsEmailAvailable(string email)
        {
            return _CiplatformDbContext.Users.Any(x => x.Email == email);
        }

        public User IsPasswordAvailable(string password, string email)
        {
            return _CiplatformDbContext.Users.Where(x => x.Password == password && x.Email == email).FirstOrDefault();
        }



        public long GetUserID(string Email)
        {
            User user = _CiplatformDbContext.Users.Where(x => x.Email == Email).FirstOrDefault();
            if (user == null)
            {

                return -1;
            }
            else
            {

                return user.UserId;
            }
        }

        //public void UpdateUserPassword(Reset_Password N)
        //{
        //    User objuser = _CiplatformDbContext.Users.FirstOrDefault(x => x.UserId == N.UserId);
        //    objuser.UpdatedAt = DateTime.Now;
        //    objuser.Password = N.Password;
        //    _CiplatformDbContext.Users.Update(objuser);
        //    _CiplatformDbContext.SaveChanges();
        //}
        public bool ResetPassword(long userId, string OldPassword, string NewPassword)
        {
            try
            {
                User user = _CiplatformDbContext.Users.Find(userId);
                string pass = (user.Password);
                if (pass == OldPassword)
                {
                    user.Password = (NewPassword);
                    _CiplatformDbContext.Users.Update(user);
                    _CiplatformDbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public Boolean ChangePassword(long UserId, Reset_Password model)
        {
            User user = _CiplatformDbContext.Users.FirstOrDefault(x => x.UserId == model.UserId);
            user.Password = model.Password;
            user.UpdatedAt = DateTime.Now;
            _CiplatformDbContext.Users.Update(user);
            _CiplatformDbContext.SaveChanges();
            return true;

        }
        public User GetUser(int userID)
        {
            try
            {

                User user = _CiplatformDbContext.Users.Where(x => x.UserId == userID).FirstOrDefault();
                if (user != null)
                {
                    return user;
                }
                else
                {

                    return null;

                }


            }
            catch (Exception ex)
            {

                return null;
            }
        }


        /*public string Authenticate(string Email)
        {
          if(!_CiplatformDbContext.Users.Any(u => u.Email == Email.ToString()))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(pwd);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, Email),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                   SecurityAlgorithms.HmacSha256Signature )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }*/
        /*public bool Reset_Password(long userId, string OldPassword, string NewPassword)
        {
            try
            {
                User user =  public bool Reset_Password(long userId, string OldPassword, string NewPassword)
                {
                    try
                    {
                        User user = _CiplatformDbContext.Users.Find(userId);
                        string pass = (user.Password);
                        if (pass == OldPassword)
                        {
                            user.Password = (NewPassword);
                            _CiplatformDbContext.Users.Update(user);
                            _CiplatformDbContext.SaveChanges();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }

                }
                public Boolean ChangePassword(long UserId, Reset_Password model)
                {
                    User user = _CiplatformDbContext.Users.FirstOrDefault(x => x.UserId == model.UserId);
                    user.Password = model.Password;
                    user.UpdatedAt = DateTime.Now;
                    _CiplatformDbContext.Users.Update(user);
                    _CiplatformDbContext.SaveChanges();
                    return true;

                }
                public User GetUser(int userID)
                {
                    try
                    {

                        User user = _CiplatformDbContext.Users.Where(x => x.UserId == userID).FirstOrDefault();
                        if (user != null)
                        {
                            return user;
                        }
                        else
                        {

                            return null;

                        }


                    }
                    catch (Exception ex)
                    {

                        return null;
                    }

                }*/

    }



}
