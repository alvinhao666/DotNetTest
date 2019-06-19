using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore
{
    public delegate Task RequestDelegate(HttpContext context);
}
