using System.Threading.Tasks;

namespace NetCore
{
    //服务器在管道中的职责非常明确，当我们自动作应用宿主的WebHost的时候，服务它被自动启动。启动后的服务器会绑定到指定的端口进行请求监听，
    //一旦有请求抵达，服务器会根据该请求创建出代表上下文的HttpContext对象，并将该上下文作为输入调用由所有注册中间件构建而成的RequestDelegate对象。
    public interface IServer
    {
        Task StartAsync(RequestDelegate handler);
    }
}
