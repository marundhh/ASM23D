using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class LockTarget : MonoBehaviour
{
    public float lockRange = 15f;
    public LayerMask enemyLayer;
    public Transform cameraTransform;

    private Transform currentTarget;
    private List<Transform> enemiesInRange = new List<Transform>();
    private int targetIndex = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (currentTarget == null)
                LockOnTarget();
            else
                UnlockTarget();
        }

        if (Input.GetKeyDown(KeyCode.Q) && currentTarget != null)
        {
            SwitchTarget();
        }

        if (currentTarget != null)
        {
            if (!IsTargetValid(currentTarget))
            {
                UnlockTarget();
            }
            else
            {
                RotateTowardsTarget();
            }
        }
    }

    void LockOnTarget()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, lockRange, enemyLayer);
        enemiesInRange = enemies.Select(e => e.transform)
                                .OrderBy(t => Vector3.Distance(transform.position, t.position))
                                .ToList();

        if (enemiesInRange.Count > 0)
        {
            targetIndex = 0;
            currentTarget = enemiesInRange[targetIndex];
        }
    }

    void UnlockTarget()
    {
        currentTarget = null;
    }

    void SwitchTarget()
    {
        if (enemiesInRange.Count < 2) return;

        targetIndex = (targetIndex + 1) % enemiesInRange.Count;
        currentTarget = enemiesInRange[targetIndex];
    }

    void RotateTowardsTarget()
    {
        if (currentTarget == null) return;

        Vector3 direction = (currentTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        cameraTransform.LookAt(currentTarget);
    }

    bool IsTargetValid(Transform target)
    {
        return target != null && Vector3.Distance(transform.position, target.position) <= lockRange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lockRange);
    }
}
