using Ecommerce_webApi.Services.Models;
using Ecommerce_webApi.Services.Services.Interfaces;
using ECommerse_webApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ECommerse_webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        public readonly IUserInfoService _userInfoService;
        public HomeController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }
        [HttpGet]
        [Route("get")]
        public IActionResult Index()
        {
            var response = _userInfoService.GetUserInfos();
            return Ok(response);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetById([FromRoute]string id)
        {
            var response = _userInfoService.GetUserInfoById(id);
            return Ok(response);
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete([FromRoute] string id)
        {
            var response = _userInfoService.DeleteUserInfo(id);
            return Ok(response);
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Create([FromBody] UserInfoDTO user)
        {
            var response = _userInfoService.AddUserInfo(user.Name,user.Email,user.Password,user.Phone);
            return Ok(response);
        }
        [HttpPost]
        [Route("update")]
        public IActionResult Update([FromBody] UserInfoDTO user)
        {
            var response = _userInfoService.UpdateUserInfo(user.Id,user.Name, user.Email, user.Password, user.Phone);
            return Ok(response);
        }
    }
}
