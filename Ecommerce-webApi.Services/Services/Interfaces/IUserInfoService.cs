using Ecommerce_webApi.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_webApi.Services.Services.Interfaces
{
    public interface IUserInfoService
    {
        Response<List<UserInfo>> GetUserInfos();
        Response<UserInfo> GetUserInfoById(string id);
        Response<UserInfo> AddUserInfo(string name,string email, string password,string phone);
        Response<UserInfo> UpdateUserInfo(string id, string name,string email, string password,string phone);
        Response<string> DeleteUserInfo(string id);
    }
}
