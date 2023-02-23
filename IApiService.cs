// See https://aka.ms/new-console-template for more information
// Interface for the API communication class
public interface IApiService
{
    Task<string> GetDataAsync();
}
