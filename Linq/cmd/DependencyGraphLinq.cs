namespace cmd;

public class DependencyGraphLinq
{
    public record Node(string Name, string[] DependsOn);

    private Dictionary<string, string[]> _edges;

    public DependencyGraphLinq(List<Node> nodes)
    {
        _edges = nodes.ToDictionary(n => n.Name, n => n.DependsOn);
    }

    public bool HasCycle(out List<string> cycle)
    {
        var visited = new HashSet<string>();
        var stack = new Stack<string>();
        var inStack = new HashSet<string>();

        foreach (var node in _edges.Keys)
        {
            if (Visit(node, visited, stack, inStack, out cycle))
                return true;
        }

        cycle = [];
        return false;
    }

    private bool Visit(
        string node, 
        HashSet<string> visited, 
        Stack<string> stack, 
        HashSet<string> inStack,
        out List<string> cycle)
    {
        if (inStack.Contains(node))
        {
            cycle = stack
                .Reverse()
                .SkipWhile(n => n != node)
                .Append(node)
                .ToList();
           
            return true;
        }

        if (visited.Contains(node))
        {
            cycle = [];
            return false;
        }

        visited.Add(node);
        inStack.Add(node);
        stack.Push(node);

        foreach (var dep in _edges.GetValueOrDefault(node) ?? Enumerable.Empty<string>())
        {
            if (Visit(dep, visited, stack, inStack, out cycle))
                return true;
        }
        
        stack.Pop();
        inStack.Remove(node);
        stack.Push(node);
        
        cycle = [];
        
        return false;
    }
}