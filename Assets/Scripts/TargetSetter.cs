using UnityEngine;

public class TargetSetter : Expert
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10.0f; // Kameradan uzaklık
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            blackboard.SetValue("targetPosition", worldPos);
        }
    }

    protected override void OnBlackboardDataChanged()
    {
        // Do nothing
    }
}
