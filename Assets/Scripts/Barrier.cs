using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private HingeJoint _hingeJoint;
    [SerializeField] private BoxCollider _boxCollider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Open();
        }
    }
    
    private void Open()
    {
        //_hingeJoint.spring.targetPosition;

        JointSpring jointSpring = _hingeJoint.spring;
        jointSpring.targetPosition = 60f;
        _hingeJoint.spring = jointSpring;

        _boxCollider.enabled = false;
    }
}
