using UnityEngine;

public class FleeState : IAIState
{
    public void UpdateState(Transform transform, Blackboard blackboard)
    {
        float fleeDistance = blackboard.GetValue<float>("FleeDistance");

        if(Vector3.Distance(transform.position, Vector3.zero) > fleeDistance)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }
    }
}