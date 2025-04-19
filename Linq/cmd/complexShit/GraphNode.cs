namespace cmd.complexShit;

public class GraphNode<T>
{
    public GraphNode(T value)
    {
        Value = value;
        Dependencies = new List<GraphNode<T>>();
    }

    public T Value { get; }
    public List<GraphNode<T>> Dependencies { get; }


    public override string ToString() => Value?.ToString() ?? "<null>";

    public override bool Equals(object? obj) =>
        obj is GraphNode<T> other && EqualityComparer<T>.Default.Equals(Value, other.Value);

    public override int GetHashCode() =>
        EqualityComparer<T>.Default.GetHashCode(Value!);
}