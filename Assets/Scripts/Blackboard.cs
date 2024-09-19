using System;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard : MonoBehaviour
{
    private Dictionary<string, object> data = new Dictionary<string, object>();
    private Dictionary<String, Action> observers = new Dictionary<string, Action>();

    public void SetValue(string key, object value)
    {
        if(data.ContainsKey(key)) data[key] = value;
        else data.Add(key, value);

        NotifyObservers(key);
    }

    public T GetValue<T>(string key)
    {
        if(data.ContainsKey(key)) return (T)data[key];
        else return default;
    }

    public void AddObsserver(string key, Action callBack)
    {
        if(!observers.ContainsKey(key)) observers.Add(key, callBack);
    }

    private void NotifyObservers(string key)
    {
        if(observers.ContainsKey(key)) observers[key]();
    }
}
