using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Blackboard blackboard;

    void Start()
    {
        blackboard = FindObjectOfType<Blackboard>();
        InvokeRepeating("RandomizeColorChangeThreshold", 1f, 2f);
        InvokeRepeating("ChangeAIState", 5f, 10f);    
    }

    void RandomizeColorChangeThreshold()
    {
        float newThreshold = Random.Range(0f, 1f);
        blackboard.SetValue("ColorChangeThreshold", newThreshold);
    }

    void ChangeAIState()
    {
        string newState = Random.value > 0.5f ? "Attack" : "Flee";
        blackboard.SetValue("AIState", newState);
    }
}