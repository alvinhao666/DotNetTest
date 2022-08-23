using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace 属性注入
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {

        public IUserService UserService { get; set; } // 不能是private

        [HttpGet]
        public IList<User> GetUsers()
        {
            return UserService.GetUsers();
        }

    }
}
