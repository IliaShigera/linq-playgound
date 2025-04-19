namespace cmd.complexShit;

public interface IInitializable
{
    string Name { get; }
    IEnumerable<string> Dependencies { get; }
    Task InitializeAsync();
}