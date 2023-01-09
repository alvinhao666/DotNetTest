using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FSharp.Json;
using NBomber;
using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;
using NBomber.Plugins.Network.Ping;


namespace NBomberTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using var httpClient = new HttpClient();

            var step = Step.Create("fetch_login", async context =>
            {
                var jsonData = new { CaptchaCode = "vyck", CaptchaId = "91b222edfba64fe1b3d7683c7bc3afa4" };

                var requestContent = new StringContent(JsonSerializer.Serialize(jsonData), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("http://localhost:8000/Dev/auth/login", requestContent);

                return response.IsSuccessStatusCode
                    ? Response.Ok()
                    : Response.Fail();
            });

            var scenario = ScenarioBuilder.CreateScenario("loginapi", step);

            NBomberRunner
                .RegisterScenarios(scenario)
                .Run();


            // var jsonData = new { CaptchaCode = "vyck", CaptchaId = "91b222edfba64fe1b3d7683c7bc3afa4" };

            // var requestContent = new StringContent(JsonSerializer.Serialize(jsonData), Encoding.UTF8, "application/json");

            // var step = Step.Create("fetch_loginapi",
            //clientFactory: HttpClientFactory.Create(),
            //execute: context =>
            //{

            //    var request = Http.CreateRequest("Post", "http://localhost:8000/Dev/auth/login")
            //        .WithBody(requestContent);

            //    return Http.Send(request, context);
            //});

            // var scenario = ScenarioBuilder
            //     .CreateScenario("loginapi", step)
            //     .WithWarmUpDuration(TimeSpan.FromSeconds(5))
            //     .WithLoadSimulations(
            //         Simulation.InjectPerSec(rate: 100, during: TimeSpan.FromSeconds(30))
            //     );

            // // creates ping plugin that brings additional reporting data
            // var pingPluginConfig = PingPluginConfig.CreateDefault(new[] { "127.0.0.1" });
            // var pingPlugin = new PingPlugin(pingPluginConfig);

            // NBomberRunner
            //     .RegisterScenarios(scenario)
            //     .WithWorkerPlugins(pingPlugin)
            //     .Run();

        }
    }
}