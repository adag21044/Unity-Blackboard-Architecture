using UnityEngine;

public abstract class Expert : MonoBehaviour
{
    protected Blackboard blackboard;

    public void Initialize(Blackboard blackboard)
    {
        this.blackboard = blackboard;
        blackboard.OnDataChanged += OnBlackboardDataChanged;
    }

    protected abstract void OnBlackboardDataChanged();
}