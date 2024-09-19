using UnityEngine;

public class VerticalMovement : IMovementStrategy
{
    public void Move(Transform transform, Blackboard blackboard)
    {
        float speed = blackboard.GetValue<float>("speed");
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}