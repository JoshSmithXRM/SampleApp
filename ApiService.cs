// See https://aka.ms/new-console-template for more information

// Interface for the API communication class
// API communication class
using Microsoft.Extensions.Configuration;

public class ApiService : IApiService
{
    private readonly IConfiguration _config;
    private readonly HttpClient _httpClient;

    public ApiService(IConfiguration config, HttpClient httpClient)
    {
        _config = config;
        _httpClient = httpClient;
    }

    public async Task<string> GetDataAsync()
    {
        var apiUrl = _config.GetValue<string>("AppSettings:ApiUrl");
        var response = await _httpClient.GetAsync(apiUrl);
        return await response.Content.ReadAsStringAsync();
    }
}
