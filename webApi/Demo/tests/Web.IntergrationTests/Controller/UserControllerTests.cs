using Demo.Domain.Entities;
using Demo.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.IntergrationTests.Common;
using Xunit;

namespace Web.IntergrationTests.Controller
{
    public class UserControllerTests: IClassFixture<CustomWebAPIFactory<Startup>>
    {
        private readonly CustomWebAPIFactory<Startup> factory;

        public UserControllerTests(CustomWebAPIFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task SuccessResult()
        {
            var client = factory.CreateClient();

            var user = new User
            {
                FirstName = "Jack",
                LastName = "Reacher",
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/User", stringContent);

            response.EnsureSuccessStatusCode();
        }
    }
}
