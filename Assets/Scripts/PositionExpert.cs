using UnityEngine;

public class PositionExpert : Expert
{
    public float speed = 2.0f;
    public float stopDistance = 0.1f; // Küplerin hedefe yaklaştığında duracağı mesafe

    private Vector3? _targetPosition = null;

    protected override void OnBlackboardDataChanged()
    {
        _targetPosition = blackboard.GetValue("targetPosition") as Vector3?;
    }

    private void Update()
    {
        if (_targetPosition.HasValue)
        {
            // Küpün hedefe olan mesafesini hesaplayın (sadece x ve z eksenlerinde)
            Vector3 targetPosition = _targetPosition.Value;
            targetPosition.y = transform.position.y; // Y eksenini sabitleyin

            float distance = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(targetPosition.x, 0, targetPosition.z));

            if (distance > stopDistance)
            {
                // Küp hareket etmeye devam eder (sadece x ve z eksenlerinde)
                Vector3 direction = (targetPosition - transform.position);
                direction.y = 0; // Y eksenini sıfırla
                transform.position += direction.normalized * speed * Time.deltaTime;
            }
        }
    }
}
