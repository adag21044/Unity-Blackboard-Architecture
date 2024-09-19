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
