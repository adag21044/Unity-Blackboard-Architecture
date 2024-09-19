using UnityEngine;

public class PositionExpert : Expert
{
    public float Speed = 2.0f;
    public float StopDistance = 0.1f;

    private Vector3? _targetPosition = null;

    protected override void OnBlackboardDataChanged(string key)
    {
        if (key == "targetPosition")
        {
            _targetPosition = Blackboard.GetValue<Vector3>("targetPosition");
        }
    }

    private void Update()
    {
        if (_targetPosition.HasValue)
        {
            Vector3 targetPosition = _targetPosition.Value;
            targetPosition.y = transform.position.y;

            float distance = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(targetPosition.x, 0, targetPosition.z));

            if (distance > StopDistance)
            {
                Vector3 direction = (targetPosition - transform.position);
                direction.y = 0;
                transform.position += direction.normalized * Speed * Time.deltaTime;
            }
        }
    }
}
