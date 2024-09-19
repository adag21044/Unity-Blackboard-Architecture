using UnityEngine;

public class FollowMovement : IMovementStrategy
{
    public void Move(Transform transform, Blackboard blackboard)
    {
        GameObject target = blackboard.GetValue<GameObject>("Target");
        if (target != null)
        {
            float speed = blackboard.GetValue<float>("Speed");
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}