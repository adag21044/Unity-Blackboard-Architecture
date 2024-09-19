using UnityEngine;

public class Prey : MonoBehaviour
{
    private Blackboard blackboard;
    private IColorChangeStrategy colorChangeStrategy;

    void Start()
    {
        blackboard = FindObjectOfType<Blackboard>();
        if (blackboard == null)
        {
            Debug.Log("Blackboard not found in the scene.");
            return;
        }

        blackboard.SetValue("Target", gameObject); // Set itself as target
        blackboard.SetValue("IsHunter", false);

        colorChangeStrategy = new ColorChangeOnProximity();
    }

    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.Log("Renderer component not found on the Prey.");
            return;
        }

        colorChangeStrategy.ChangeColor(renderer, blackboard);
    }
}