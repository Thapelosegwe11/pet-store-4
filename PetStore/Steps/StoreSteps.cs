using System.Collections.Generic;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using RestSharp;

namespace Applications.PetStore.Steps
{
    public class StoreSteps
    {
        private Dictionary<string, int> _inventory;

        [Step("Get store inventory")]
        public void GetStoreInventory()
{
            var client = new RestClient("http://localhost/v2");
            var request = new RestRequest("/store/inventory", Method.GET);
            var response = client.Execute<Dictionary<string, int>>(request);
            _inventory = response.Data;
            _inventory.Should().NotBeEmpty();
        }

        [Step("Check that inventory has status <status>")]
        public void CheckStatus(string status)
        {
            _inventory.Keys.Should().Contain(status);
        }
    }
}