using UnityEngine;

public class ColorChangeOnProximity : IColorChangeStrategy
{
    public void ChangeColor(Renderer renderer, Blackboard blackboard)
    {
        GameObject target = blackboard.GetValue<GameObject>("Target");
        float distanceThreshold = blackboard.GetValue<float>("DistanceThreshold");
        float distance = Vector3.Distance(renderer.transform.position, target.transform.position);

        if (distance < distanceThreshold)
        {
            if (blackboard.GetValue<bool>("IsHunter"))
                renderer.material.color = Color.blue; // Hunter turns blue
            else
                renderer.material.color = Color.red; // Target (prey) turns red
        }
        else
        {
            renderer.material.color = Color.white; // All turn white
        }
    }
}