using UnityEngine;

public class BlackBoardController : MonoBehaviour
{
    private Blackboard _blackboard;

    private void Start()
    {
        _blackboard = new Blackboard();

        foreach (var expert in FindObjectsOfType<Expert>())
        {
            expert.Initialize(_blackboard);
        }
    }
}
