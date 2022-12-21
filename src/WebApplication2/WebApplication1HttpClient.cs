namespace WebApplication2;

public class WebApplication1HttpClient
{
    private readonly HttpClient _client;
    public WebApplication1HttpClient(HttpClient client)
    {
        _client = client;
        var baseAdress = Environment.GetEnvironmentVariable("WEB_APP_1_URI");
        if (baseAdress is null)
            throw new NullReferenceException();
        _client.BaseAddress = new Uri(baseAdress);
    }

    public async Task<string> GetWebApplication1Test()
    {
        var message = new HttpRequestMessage()
        {
            RequestUri = new Uri($"{_client.BaseAddress}weatherforecast"),
            Method = HttpMethod.Get,
        };

        var response = await _client.SendAsync(message);
        var content = await response.Content.ReadAsStringAsync();

        return content;
    }
}
