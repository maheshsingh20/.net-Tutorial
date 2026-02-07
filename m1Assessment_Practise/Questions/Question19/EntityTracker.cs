using System.Reflection;

namespace m1Assessment_Practise.Questions.Question19;

class EntityTracker<T> where T : class
{
    private readonly Dictionary<string, object?> _originalValues = new();

    public void StartTracking(T entity)
    {
        _originalValues.Clear();
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        
        foreach (var prop in properties)
        {
            if (prop.CanRead)
            {
                _originalValues[prop.Name] = prop.GetValue(entity);
            }
        }
    }

    public List<AuditEntry> GetChanges(T entity)
    {
        var changes = new List<AuditEntry>();
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in properties)
        {
            if (!prop.CanRead)
                continue;

            var currentValue = prop.GetValue(entity);
            
            if (_originalValues.TryGetValue(prop.Name, out var originalValue))
            {
                bool hasChanged = !Equals(originalValue, currentValue);
                
                if (hasChanged)
                {
                    changes.Add(new AuditEntry
                    {
                        EntityName = typeof(T).Name,
                        PropertyName = prop.Name,
                        OldValue = originalValue,
                        NewValue = currentValue,
                        Timestamp = DateTime.Now
                    });
                }
            }
        }

        return changes;
    }
}
