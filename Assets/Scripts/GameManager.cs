using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject hunterPrefab;
    public GameObject preyPrefab;
    public float distanceThreshold = 5f;
    public float speed = 2f;

    private Blackboard blackboard;

    void Start()
    {
        blackboard = FindObjectOfType<Blackboard>();
        if (blackboard == null)
        {
            Debug.Log("Blackboard not found in the scene.");
            return;
        }

        blackboard.SetValue("DistanceThreshold", distanceThreshold);
        blackboard.SetValue("Speed", speed);

        CreateHuntersAndPreys();
    }

    private void CreateHuntersAndPreys()
    {
        if (hunterPrefab == null || preyPrefab == null)
        {
            Debug.Log("Hunter or Prey prefab is not assigned.");
            return;
        }

        // Create a hunter and a prey for demonstration
        GameObject hunter = Instantiate(hunterPrefab, new Vector3(-10, 0, 0), Quaternion.identity);
        GameObject prey = Instantiate(preyPrefab, new Vector3(10, 0, 0), Quaternion.identity);

        blackboard.SetValue("Target", prey); // Set the prey as the target for the hunter
    }
}
