using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankAttack : MonoBehaviour
{
    protected Transform _target;
    protected readonly float _angleThreshold;

    protected TankAttack(float angleThreshold)
    {
        _angleThreshold = angleThreshold;
    }

    protected void LookAtDirection(Vector3 targetPosition, Transform turretTransform)
    {
        if (targetPosition != null)
        {
            Vector3 direction = targetPosition - turretTransform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            turretTransform.rotation = targetRotation;
        }
    }

    protected bool IsTurretFacingTarget(Vector3 targetPosition, Transform turretTransform)
    {
        Vector3 directionToTarget = targetPosition - turretTransform.position;
        float angle = Vector3.Angle(turretTransform.forward, directionToTarget);
        return angle <= _angleThreshold;
    }
}
