using UnityEngine;

public class Hunter : MonoBehaviour
{
    private Blackboard blackboard;
    private IMovementStrategy movementStrategy;
    private IColorChangeStrategy colorChangeStrategy;

    void Start()
    {
        blackboard = FindObjectOfType<Blackboard>();
        
        if (blackboard == null)
        {
            Debug.Log("Blackboard not found in the scene.");
            return;
        }
        blackboard.SetValue("Target", null); // Initial target is null
        blackboard.SetValue("IsHunter", true);
        
        movementStrategy = new FollowMovement();
        colorChangeStrategy = new ColorChangeOnProximity();
    }

    void Update()
    {
        if (blackboard == null)
        {
            Debug.Log("Blackboard is null.");
            return;
        }

        Renderer renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("Renderer component not found on the Hunter.");
            return;
        }

        movementStrategy.Move(transform, blackboard);
        colorChangeStrategy.ChangeColor(renderer, blackboard);

        CheckForPrey();
    }

    private void CheckForPrey()
    {
        GameObject target = blackboard.GetValue<GameObject>("Target");
        if (target != null && Vector3.Distance(transform.position, target.transform.position) < blackboard.GetValue<float>("DistanceThreshold"))
        {
            Destroy(target); // Prey is caught
            blackboard.SetValue("Target", null); // Remove target from blackboard
        }
    }
}