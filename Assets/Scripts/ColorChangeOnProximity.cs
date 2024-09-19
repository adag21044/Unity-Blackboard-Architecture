using UnityEngine;

public class ColorChangeOnProximity : IColorChangeStrategy
{
    public void ChangeColor(Renderer renderer, Blackboard blackboard)
    {
        if (renderer == null || blackboard == null) // Null kontrolü ekleyin
        {
            Debug.Log("Renderer or Blackboard is null.");
            return;
        }

        GameObject target = blackboard.GetValue<GameObject>("Target");
        if (target == null)
        {
            Debug.Log("Target is null.");
            return;
        }

        float distanceThreshold = blackboard.GetValue<float>("DistanceThreshold");
        float distance = Vector3.Distance(renderer.transform.position, target.transform.position);

        if (distance < distanceThreshold)
        {
            renderer.material.color = Color.red; // Target (prey) turns red
            if (blackboard.GetValue<bool>("IsHunter"))
                renderer.material.color = Color.blue; // Hunter turns blue
        }
        else
        {
            renderer.material.color = Color.white; // All turn white
        }
    }
}
