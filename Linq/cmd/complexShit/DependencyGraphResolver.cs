namespace cmd.complexShit;

public class DependencyGraphResolver<T>
{
    public IReadOnlyList<GraphNode<T>> TopologicalSort(IEnumerable<GraphNode<T>> nodes)
    {
        var visited = new HashSet<GraphNode<T>>();
        var visiting = new HashSet<GraphNode<T>>();
        var result = new List<GraphNode<T>>();

        foreach (var node in nodes)
            Visit(node, visited, visiting, result);

        result.Reverse();
        return result;
    }

    private void Visit(
        GraphNode<T> node,
        HashSet<GraphNode<T>> visited,
        HashSet<GraphNode<T>> visiting,
        List<GraphNode<T>> result)
    {
        if (visited.Contains(node))
            return;

        if (visiting.Contains(node))
            throw new InvalidOperationException($"Cycle detected at {node.Value}");

        visiting.Add(node);

        foreach (var dep in node.Dependencies.Distinct())
            Visit(dep, visited, visiting, result);

        visiting.Remove(node);
        visited.Add(node);
        result.Add(node);
    }
}