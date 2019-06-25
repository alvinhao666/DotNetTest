using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            List<Person> list = new List<Person>();
            for(int i=0;i<2;i++)
            {
                list.Add(new Person() { Name = "Name" + i, Age = i + 1 });
            }
            return list;
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
