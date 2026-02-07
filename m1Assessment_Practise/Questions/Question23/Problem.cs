// Question 23: Plugin Loader (Reflection + Interface)
namespace m1Assessment_Practise.Questions.Question23;

class Problem
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Question 23: Plugin Loader ===\n");

        var plugins = new List<IPlugin>
        {
            new SamplePlugin1(),
            new SamplePlugin2()
        };

        Console.WriteLine($"Loaded {plugins.Count} plugins\n");

        foreach (var plugin in plugins)
        {
            Console.WriteLine($"Running: {plugin.Name}");
            plugin.Execute();
            Console.WriteLine();
        }
    }
}
