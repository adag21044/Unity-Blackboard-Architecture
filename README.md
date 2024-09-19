# Unity Blackboard Architecture

## Overview

This project demonstrates an implementation of the Blackboard architecture pattern in Unity. The Blackboard pattern is used for managing and sharing data between different components (or "experts") in a decoupled manner. This approach is commonly used in AI systems, where multiple components need to collaborate by accessing and modifying shared data.

## Project Structure

### 1. Blackboard Class

The `Blackboard` class serves as the central data repository. It allows different components to store and retrieve data while notifying subscribers of any changes.

```csharp
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
```

### 2. Expert Class

The `Expert` class is an abstract base class for components that interact with the `Blackboard`. Each concrete subclass of `Expert` will implement its own logic for reacting to changes in the `Blackboard`.

```csharp
using UnityEngine;

public abstract class Expert : MonoBehaviour
{
    protected Blackboard Blackboard { get; private set; }

    public void Initialize(Blackboard blackboard)
    {
        Blackboard = blackboard;
        blackboard.OnDataChanged += OnBlackboardDataChanged;
    }

    protected abstract void OnBlackboardDataChanged(string key);
}
```

### 3. PositionExpert Class

The `PositionExpert` class is a concrete implementation of `Expert` that moves an object towards a target position. It updates its position based on data changes in the `Blackboard`.

```csharp
using UnityEngine;

public class PositionExpert : Expert
{
    public float Speed = 2.0f;
    public float StopDistance = 0.1f;

    private Vector3? _targetPosition = null;

    protected override void OnBlackboardDataChanged(string key)
    {
        if (key == "targetPosition")
        {
            _targetPosition = Blackboard.GetValue<Vector3>("targetPosition");
        }
    }

    private void Update()
    {
        if (_targetPosition.HasValue)
        {
            Vector3 targetPosition = _targetPosition.Value;
            targetPosition.y = transform.position.y;

            float distance = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(targetPosition.x, 0, targetPosition.z));

            if (distance > StopDistance)
            {
                Vector3 direction = (targetPosition - transform.position);
                direction.y = 0;
                transform.position += direction.normalized * Speed * Time.deltaTime;
            }
        }
    }
}
```

### 4. TargetSetter Class

The `TargetSetter` class is another concrete implementation of `Expert`. It sets a target position in the `Blackboard` based on user input (mouse click).

```csharp

using UnityEngine;

public class TargetSetter : Expert
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10.0f;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Blackboard.SetValue("targetPosition", worldPos);
        }
    }

    protected override void OnBlackboardDataChanged(string key)
    {
        // Do nothing
    }
}
```

### 5. BlackBoardController Class

The `BlackBoardController` class initializes the `Blackboard` and sets up the `Expert` components in the scene to use it.

```csharp
using UnityEngine;

public class BlackBoardController : MonoBehaviour
{
    private Blackboard _blackboard;

    private void Start()
    {
        _blackboard = new Blackboard();

        foreach (var expert in FindObjectsOfType<Expert>())
        {
            expert.Initialize(_blackboard);
        }
    }
}
```
