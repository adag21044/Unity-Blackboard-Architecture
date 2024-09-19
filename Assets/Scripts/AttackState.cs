using UnityEngine;

public class AttackState :IAIState
{
    public void UpdateState(Transform transform, Blackboard blackboard)
    {
        // Attack
        float attackRange = blackboard.GetValue<float>("AttackRange");

        if(Vector3.Distance(transform.position, Vector3.zero) < attackRange)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}
    
