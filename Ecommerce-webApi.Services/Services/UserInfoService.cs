using Ecommerce_webApi.Services.Models;
using Ecommerce_webApi.Services.Services.Interfaces;
using ECommerse_webApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_webApi.Services.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly ContactManagementDbContext _context;
        public UserInfoService(ContactManagementDbContext context) {
        _context = context;
        }
        public Response<List<UserInfo>> GetUserInfos()
        {
            var response = new Response<List<Models.UserInfo>>();
            try
            {
                var userInfos = _context.UserInfos;
                if(userInfos== null)
                {
                    response.CreateError("No Data Found");
                }
                else
                {
                    response.CreateSuccess(userInfos.ToList());

                }
            }
            catch (Exception ex)
            {
                response.CreateError(ex.Message);
            }
            return response;
        }

         public  Response<UserInfo> AddUserInfo(string name, string email, string password, string phone)
        {
            var response = new Response<UserInfo>();
            try
            {
                var userInfo = new UserInfo()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name,
                    Email = email,
                    Password = password,
                    Phone = phone
                };
                _context.UserInfos.Add(userInfo);
                _context.SaveChanges();
                response.CreateSuccess(userInfo);
            }catch(Exception ex)
            {
                response.CreateError(ex.Message);

            }
            return response;
        }

       public Response<string> DeleteUserInfo(string id)
        {
            var response = new Response<string>();
            try
            {
                var userInfo = this.GetUserInfoById(id);
                if (userInfo == null )
                {
                    response.CreateError("User Not found");
                }
                if(userInfo != null && userInfo.HasError)
                {
                    response.CreateError(userInfo.ErrorMessage);
                }
                if (userInfo != null && !userInfo.HasError)
                {
                    _context.UserInfos.Remove(userInfo.Result);
                    _context.SaveChanges();
                    response.CreateSuccess("Deleted Successfully");
                }
            }catch (Exception ex)
            {
                response.CreateError(ex.Message);
            }
            return response;
        }

       public Response<UserInfo> GetUserInfoById(string id)
        {
            var response = new Response<Models.UserInfo>();
            try
            {
                var user = _context.UserInfos.FirstOrDefault(x => x.Id == id);
                response.CreateSuccess(user);

            }catch(Exception ex) {
            response.CreateError(ex.Message);
            }
            return response;
        }

        public Response<UserInfo> UpdateUserInfo(string id, string name, string email, string password, string phone)
        {
            var response = new Response<UserInfo>();
            try
            {
                var userInfo = this.GetUserInfoById(id);
                if (userInfo == null)
                {
                    response.CreateError("User Not found");
                }
               else if (userInfo.HasError)
                {
                    response.CreateError(userInfo.ErrorMessage);
                }
                else
                {
                    userInfo.Result.Name = name;
                    userInfo.Result.Email = email;
                    userInfo.Result.Password = password;
                    userInfo.Result.Phone = phone;
                    _context.UserInfos.Update(userInfo.Result);
                    _context.SaveChanges();

                    response.CreateSuccess(userInfo.Result);
                }

            }
            catch(Exception ex)
            {response.CreateError(ex.Message);

            }
            return response;
        }
    }
}
