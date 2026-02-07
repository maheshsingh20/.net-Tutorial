using System.Reflection;

namespace m1Assessment_Practise.Questions.Question23;

class PluginLoader
{
    public List<IPlugin> LoadPlugins(string folderPath)
    {
        var plugins = new List<IPlugin>();

        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine($"Plugin folder not found: {folderPath}");
            return plugins;
        }

        var dllFiles = Directory.GetFiles(folderPath, "*.dll");

        foreach (var dllPath in dllFiles)
        {
            try
            {
                var assembly = Assembly.LoadFrom(dllPath);
                var pluginTypes = assembly.GetTypes()
                    .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                foreach (var type in pluginTypes)
                {
                    var plugin = (IPlugin?)Activator.CreateInstance(type);
                    if (plugin != null)
                    {
                        plugins.Add(plugin);
                        Console.WriteLine($"Loaded plugin: {plugin.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load {Path.GetFileName(dllPath)}: {ex.Message}");
            }
        }

        return plugins;
    }
}
