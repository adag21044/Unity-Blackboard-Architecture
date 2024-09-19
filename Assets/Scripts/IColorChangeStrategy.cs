using UnityEngine;

public interface IColorChangeStrategy
{
    void ChangeColor(Renderer renderer, Blackboard blackboard);
}