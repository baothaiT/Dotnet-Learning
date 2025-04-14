using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.IntegrationTest.Product;

public class ProductFixture : CQRSApplicationFactory
{
    public const string Endpoint_GetProducts = "/products";
    public HttpClient HttpClient => Server.CreateClient();
}
