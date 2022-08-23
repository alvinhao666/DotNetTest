using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace Configuration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        protected IConfiguration Configuration;

        protected MySettings MySettings1;

        protected MySettings MySettings2;



        public ValuesController(

            IOptions<MySettings> settings1, //不支持热更新 IOptions<> 生命周期为Singleton，初始化的时候配置就已经存入缓存，并且不再更新

            IOptionsSnapshot<MySettings> settings2, //支持热更新 IOptionsSnapshot<> 生命周期为Scope，初始化的时候会写入缓存，内容由OptionsMonitor提供，初始化OptionsMonitor的时候会给所有的IOtionsChangeTokenSource<T>对象的ChangeToken注册一个重载配置的方法

            IConfiguration configuration = null)

        {

            MySettings1 = settings1.Value;
            MySettings2 = settings2.Value;

            Configuration = configuration;

        }



        public IActionResult Index()

        {
            //操作的是最外部的appsettings.json,不是bin目录里面的
            var m1 = MySettings1.Message;//不会变

            var m12 = MySettings2.Message;//会变 reloadonchange为true; 不会变 reloadonchange为false 或者不设置值   

            var m2 = Configuration["MySettings:Message"]; //会变 且跟reloadonchange无关****

            var id = Configuration["NanRuiClientId"];

            List<Guid> ids = new List<Guid>();
            Configuration.GetSection("NanRuiClientIds").Bind(ids);

            var clientids = Configuration.GetValue<List<Guid>>("NanRuiClientIds");

            return Content($" m1:{m1}\r\n m12:{m12}\r\n m2:{m2}");

        }

        public class ClientId
        {
            public List<string> ids { get; set; }
        }
    }
}
