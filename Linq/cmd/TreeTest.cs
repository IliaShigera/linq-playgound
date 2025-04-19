namespace cmd;

public static class TreeTest
{
    public record Employee(int Id, string Name, int? ManagerId);

    public record EmployeeNode(Employee Data, List<EmployeeNode> Subordinates);

    private static List<Employee> Employees =
    [
        new(1, "CEO", null),
        new(2, "CTO", 1),
        new(3, "CFO", 1),
        new(4, "Dev1", 2),
        new(5, "Dev2", 2),
        new(6, "Acc1", 3)
    ];

    public static List<EmployeeNode> BuildTree(int? managerId)
    {
        var lookup = Employees.ToLookup(e => e.ManagerId);
        return lookup[managerId]
            .Select(empl => new EmployeeNode(empl, BuildTree(empl.Id)))
            .ToList();
    }
    
    public static void PrintTree(IEnumerable<EmployeeNode> nodes, string indent = "")
    {
        foreach (var node in nodes)
        {
            Console.WriteLine($"{indent}- {node.Data.Name}");
            PrintTree(node.Subordinates, indent + "  ");
        }
    }
}