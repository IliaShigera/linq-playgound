namespace cmd.complexShit;

public class LoggerService : IInitializable
{
    public string Name => nameof(LoggerService);

    public IEnumerable<string> Dependencies => Enumerable.Empty<string>();

    public Task InitializeAsync()
    {
        Console.WriteLine(nameof(LoggerService) + " initialized.");
        return Task.CompletedTask;
    }
}

public class MetricsService : IInitializable
{
    public string Name => nameof(MetricsService);
    public IEnumerable<string> Dependencies => [nameof(LoggerService)];

    public async Task InitializeAsync()
    {
        Console.WriteLine($"{nameof(MetricsService)} initialized.");
        await Task.Delay(100);
    }
}

public class CoolService : IInitializable
{
    public string Name => nameof(CoolService);
    public IEnumerable<string> Dependencies => [nameof(LoggerService), nameof(MetricsService)];

    public async Task InitializeAsync()
    {
        Console.WriteLine("Ya skazala Startuuuuuem! (start)");
        await Task.Delay(100);
    }
}

public class FuckedUpService : IInitializable
{
    public string Name => nameof(FuckedUpService);
    public IEnumerable<string> Dependencies => ["ThisServiceDoestExist"];

    public async Task InitializeAsync()
    {
        Console.WriteLine($"{nameof(FuckedUpService)} initialized. (thats fucked up)");
        await Task.Delay(100);
    }
}

public class VeryImportantService1 : IInitializable
{
    public string Name => nameof(VeryImportantService1);
    public IEnumerable<string> Dependencies => [nameof(VeryImportantService2)];
    
    public  Task InitializeAsync()
    {
        return Task.CompletedTask;
    }
}
public class VeryImportantService2 : IInitializable
{
    public string Name => nameof(VeryImportantService2);
    public IEnumerable<string> Dependencies => [nameof(VeryImportantService1)];
    
    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }
}
