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
        blackboard.SetValue("DistanceThreshold", distanceThreshold);
        blackboard.SetValue("Speed", speed);

        CreateHuntersAndPreys();
    }

    private void CreateHuntersAndPreys()
    {
        // Create a hunter and a prey for demonstration
        GameObject hunter = Instantiate(hunterPrefab, new Vector3(-10, 0, 0), Quaternion.identity);
        GameObject prey = Instantiate(preyPrefab, new Vector3(10, 0, 0), Quaternion.identity);

        blackboard.SetValue("Target", prey); // Set the prey as the target for the hunter
    }
}
