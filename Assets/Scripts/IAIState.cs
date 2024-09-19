using UnityEngine;

public interface IAIState 
{
    void UpdateState(Transform transform, Blackboard blackboard);
}