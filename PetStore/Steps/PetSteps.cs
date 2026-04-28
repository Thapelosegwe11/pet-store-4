using System.Collections.Generic;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using RestSharp;
using Newtonsoft.Json;

namespace Applications.PetStore.Steps
{
    public class PetSteps
    {
        private int _petId;

        [Step("Add a pet with name <name> in category <category>")]
        public void AddPet(string name, string category)
        {
            var client = new RestClient("http://localhost/v2");
            var request = new RestRequest("/pet", Method.POST);
            request.AddJsonBody(new
            {
                name = name,
                status = "available",
                photoUrls = new[] { "http://example.com/photo.jpg" },
                category = new { name = category }
            });
            var response = client.Execute(request);
            var pet = JsonConvert.DeserializeObject<dynamic>(response.Content);
            _petId = (int)pet.id;
        }

        [Step("Verify that pet with name <name> exists in the store")]
        public void VerifyPetExists(string name)
        {
            var client = new RestClient("http://localhost/v2");
            var request = new RestRequest($"/pet/{_petId}", Method.GET);
            var response = client.Execute(request);
            response.Content.Should().Contain(name);
        }

        [Step("Delete the pet with name <name>")]
        public void DeletePet(string name)
        {
            var client = new RestClient("http://localhost/v2");
            var request = new RestRequest($"/pet/{_petId}", Method.DELETE);
            client.Execute(request);
        }

        [Step("Verify that pet with name <name> does not exist in the store")]
        public void VerifyPetDoesNotExist(string name)
        {
            var client = new RestClient("http://localhost/v2");
            var request = new RestRequest($"/pet/{_petId}", Method.GET);
            var response = client.Execute(request);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }
    }
}