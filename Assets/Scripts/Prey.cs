using UnityEngine;

public class Prey : MonoBehaviour
{
    private Blackboard blackboard;
    private IColorChangeStrategy colorChangeStrategy;

    void Start()
    {
        blackboard = FindObjectOfType<Blackboard>();
        blackboard.SetValue("Target", gameObject); // Set itself as target
        blackboard.SetValue("IsHunter", false);
        
        colorChangeStrategy = new ColorChangeOnProximity();
    }

    void Update()
    {
        colorChangeStrategy.ChangeColor(GetComponent<Renderer>(), blackboard);
    }
}