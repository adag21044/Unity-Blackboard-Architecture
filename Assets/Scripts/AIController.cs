using UnityEngine;

public class AIController : MonoBehaviour
{
    private Blackboard blackboard;
    private IMovementStrategy movementStrategy;
    private IColorChangeStrategy colorChangeStrategy;
    private IAIState currentState;
    private Renderer cubeRenderer;

    void Start()
    {
        blackboard = FindObjectOfType<Blackboard>();
        cubeRenderer = GetComponent<Renderer>();

        movementStrategy = new HorizontalMovement();
        colorChangeStrategy = new RandomColorChange();
        currentState = new AttackState(); // Initial state

        blackboard.AddObsserver("ColorChangeThreshold", () => colorChangeStrategy.ChangeColor(cubeRenderer, blackboard));
        blackboard.AddObsserver("AIState", () => ChangeState(blackboard.GetValue<string>("AIState")));
    }

    void Update()
    {
        movementStrategy.Move(transform, blackboard);
        currentState.UpdateState(transform, blackboard);
    }

    private void ChangeState(string newState)
    {
        switch(newState)
        {
            case "Attack":
                currentState = new AttackState();
                break;
            case "flee":
                currentState = new FleeState();
                break;
            default:
                currentState = new AttackState(); // Default state
                break;
        }
    }
}