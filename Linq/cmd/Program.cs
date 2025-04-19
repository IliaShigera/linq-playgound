using cmd;
using cmd.complexShit;

var services = new IInitializable[]
{
    new LoggerService(),
    new MetricsService(),
    new CoolService(),
    // new FuckedUpService(), 
    // new VeryImportantService1(),
    // new VeryImportantService2()
};

await new ServiceInitializer().InitializeAsync(services);

// Console.WriteLine("Hello, World!");


// var tree = TreeTest.BuildTree(3);
// TreeTest.PrintTree(tree);


// List<string> skills = ["C#", "  SQL ", null, "C#", "LINQ", "sql", " ", "Linq"];
// var res = NormilizeSkillsLinq.NormalizeSkills(skills);
// Console.WriteLine(res);

// List<DependencyGraphLinq.Node> nodes =
// [
//     new("A", ["B"]),
//     new("B", ["C"]),
//     new("C", ["D"]),
//     new("D", ["B"]), // <--
// ];
//
// var graph = new DependencyGraphLinq(nodes);
// var res = graph.HasCycle(out var cycle)
//     ? $"Cycle detected: {string.Join("-->", cycle)}"
//     : "No cycle detected.";
// Console.WriteLine(res);