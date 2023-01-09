using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FSharp.Json;
using NBomber;
using NBomber.Contracts;
using NBomber.CSharp;

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

        }
    }
}