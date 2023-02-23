public class App
{
    private readonly DataCoordinator _dataCoordinator;

    public App(DataCoordinator dataCoordinator)
    {
        _dataCoordinator = dataCoordinator;
    }

    public async Task RunAsync()
    {
        await _dataCoordinator.GetDataAndSaveAsync();
    }
}