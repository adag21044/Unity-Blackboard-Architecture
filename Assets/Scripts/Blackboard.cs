using System;
using System.Collections.Generic;

public class Blackboard 
{
    private Dictionary<string, object> _data = new Dictionary<string, object>();
    public event Action OnDataChanged;

    public void SetValue(string key, object value)
    {
        _data[key] = value;
        OnDataChanged?.Invoke();
    }

    public object GetValue(string key)
    {
        if(_data.ContainsKey(key))return _data[key];
        
        return null;
    }
}