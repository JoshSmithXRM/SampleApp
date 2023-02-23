// See https://aka.ms/new-console-template for more information

// Interface for the API communication class
// Coordinator class to communicate between the API and database classes
public class DataCoordinator
{
    private readonly IApiService _apiService;
    private readonly IDatabaseService _databaseService;

    public DataCoordinator(IApiService apiService, IDatabaseService databaseService)
    {
        _apiService = apiService;
        _databaseService = databaseService;
    }

    public async Task GetDataAndSaveAsync()
    {
        var data = await _apiService.GetDataAsync();
        _databaseService.SaveData(data);
    }
}
