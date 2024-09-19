using UnityEngine;

public class BlackBoardController : MonoBehaviour
{
    private Blackboard blackboard;

    private void Start()
    {
        blackboard = new Blackboard();
        
        Expert[] experts = FindObjectsOfType<Expert>();

        foreach(Expert expert in experts)
        {
            expert.Initialize(blackboard);
        }
    }
}