using UnityEngine;
using System;
using System.Collections.Generic;

public class Blackboard : MonoBehaviour
{
    private Dictionary<string, object> data = new Dictionary<string, object>();
    private Dictionary<string, Action> observers = new Dictionary<string, Action>();

    public void SetValue(string key, object value)
    {
        if (data.ContainsKey(key))
            data[key] = value;
        else
            data.Add(key, value);

        NotifyObservers(key);
    }

    public T GetValue<T>(string key)
    {
        if (data.ContainsKey(key))
            return (T)data[key];
        else
            return default;
    }

    public void AddObserver(string key, Action callback)
    {
        if (!observers.ContainsKey(key))
            observers.Add(key, callback);
    }

    private void NotifyObservers(string key)
    {
        if (observers.ContainsKey(key))
            observers[key]();
    }
}
