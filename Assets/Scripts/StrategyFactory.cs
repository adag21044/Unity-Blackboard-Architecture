public class StrategyFactory 
{
    public static IMovementStrategy CreateMovementStrategy(string type)
    {
        switch(type)
        {
            case "VerticalMovement":
                return new VerticalMovement();
            case "HorizontalMovement":
                return new HorizontalMovement();
            default:
                return null;
        }
    }

    public static IColorChangeStrategy CreateColorChangeStrategy(string type)
    {
        switch(type)
        {
            case "RandomColorChange":
                return new RandomColorChange();
            default:
                return null;
        }
    }

    public static IAIState CreateAIState(string type)
    {
        switch(type)
        {
            case "AttackState":
                return new AttackState();
            case "FleeState":
                return new FleeState();
            default:
                return new AttackState();
        }
    }
}