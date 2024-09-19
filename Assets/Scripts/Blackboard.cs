using System;
using System.Collections.Generic;

public class Blackboard
{
    private readonly Dictionary<string, object> _data = new Dictionary<string, object>();
    public event Action<string> OnDataChanged;

    public void SetValue<T>(string key, T value)
    {
        _data[key] = value;
        OnDataChanged?.Invoke(key);
    }

    public T GetValue<T>(string key)
    {
        if (_data.TryGetValue(key, out var value))
        {
            return (T)value;
        }
        
        return default;
    }
}
