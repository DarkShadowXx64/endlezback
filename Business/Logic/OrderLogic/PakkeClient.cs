using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace Business.Logic.OrderLogic;

public class PakkeClient : HttpClient
{
    public PakkeClient(IConfiguration config)
    {
        this.BaseAddress = new Uri("https://seller.pakke.mx/api/v1/");
        this.Timeout = TimeSpan.FromSeconds(10);
        this.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(string.Empty,config["Pakke:ApiKey"]);
    }
}