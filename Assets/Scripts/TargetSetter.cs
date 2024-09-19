using UnityEngine;

public class TargetSetter : Expert
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10.0f;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Blackboard.SetValue("targetPosition", worldPos);
        }
    }

    protected override void OnBlackboardDataChanged(string key)
    {
        // Do nothing
    }
}
