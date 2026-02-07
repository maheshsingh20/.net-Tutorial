namespace m1Assessment_Practise.Questions.Question24;

class ConfigManager
{
    private static readonly Lazy<ConfigManager> _instance = 
        new Lazy<ConfigManager>(() => new ConfigManager(), LazyThreadSafetyMode.ExecutionAndPublication);

    private readonly Dictionary<string, string> _settings = new();
    private readonly object _lock = new();

    private ConfigManager()
    {
        LoadSettings();
    }

    public static ConfigManager Instance => _instance.Value;

    private void LoadSettings()
    {
        _settings["AppName"] = "MyApplication";
        _settings["Version"] = "1.0.0";
        _settings["MaxConnections"] = "100";
    }

    public string? GetSetting(string key)
    {
        lock (_lock)
        {
            return _settings.TryGetValue(key, out var value) ? value : null;
        }
    }

    public void SetSetting(string key, string value)
    {
        lock (_lock)
        {
            _settings[key] = value;
        }
    }
}
