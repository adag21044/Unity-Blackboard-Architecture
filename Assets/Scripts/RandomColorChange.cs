using UnityEngine;

public class RandomColorChange : IColorChangeStrategy
{
    public void ChangeColor(Renderer renderer, Blackboard blackboard)
    {
        float threshold = blackboard.GetValue<float>("ColorChangeThreshold");       

        if(Random.Range(0f, 1f) > threshold)
        {
            renderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}