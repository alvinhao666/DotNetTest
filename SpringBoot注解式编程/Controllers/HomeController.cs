using System;
using Microsoft.AspNetCore.Mvc;

namespace SpringBoot注解式编程.Controllers
{
    public class HomeController : Controller
    {
        [Autowired]
        public ICar Car{ set; get; }

        [Value("description")]
        public string Description { set; get; }
        
        

        public void Index()
        {
            var car = Car;

            Console.WriteLine(Description);

            Car.Fire();
        }
    }
}