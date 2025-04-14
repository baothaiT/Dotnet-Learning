using CQRS.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.IntegrationTest.Product
{
    public class ProductUnitTest : IClassFixture<ProductFixture>
    {
        private readonly ProductFixture _fixture;

        public ProductUnitTest(ProductFixture fixture) => _fixture = fixture;

        [Fact]
        public async Task Get_Product_Success()
        {
            string url = ProductFixture.Endpoint_GetProducts;

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _fixture.HttpClient.SendAsync(request).ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Read and parse the response content
            var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            Assert.False(string.IsNullOrWhiteSpace(contentString), "Response content should not be empty.");

            // Deserialize JSON into a list of products (assuming a Product class exists)
            var products = JsonConvert.DeserializeObject<List<ProductEntity>>(contentString);

            Assert.NotNull(products);
            Assert.NotEmpty(products); // Optional: Check that there is at least one product
        }



    }
}
