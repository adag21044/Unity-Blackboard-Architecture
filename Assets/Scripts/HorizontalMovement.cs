using UnityEngine;

public class HorizontalMovement : IMovementStrategy
{
    public void Move(Transform transform, Blackboard blackboard)
    {
        float speed = blackboard.GetValue<float>("speed");
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}