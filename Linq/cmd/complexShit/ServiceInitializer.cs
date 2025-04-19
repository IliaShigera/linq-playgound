using System.Diagnostics.CodeAnalysis;

namespace cmd.complexShit;

[SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
public class ServiceInitializer
{
    public async Task InitializeAsync(IEnumerable<IInitializable> services)
    {
        var map = services.ToDictionary(c => c.Name);
        var nodes = services.Select(c => new GraphNode<IInitializable>(c)).ToList();

        foreach (var node in nodes)
        {
            foreach (var depName in node.Value.Dependencies ?? Enumerable.Empty<string>())
            {
                if (!map.TryGetValue(depName, out var dep))
                    throw new InvalidOperationException($"Missing dependency: {depName} for {node.Value.Name}");

                var depNode = nodes.First(n => n.Value == dep);
                node.Dependencies.Add(depNode);
            }
        }

        var resolver = new DependencyGraphResolver<IInitializable>();
        var sorted = resolver.TopologicalSort(nodes);

        foreach (var node in sorted)
        {
            Console.WriteLine($"Initializing: {node.Value.Name}");
            await node.Value.InitializeAsync();
        }
    }
}