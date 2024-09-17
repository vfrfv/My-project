using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public CinemachineVirtualCamera camera1;
    public CinemachineVirtualCamera camera2;

    private void Awake()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            camera1.enabled = false;
            camera2.enabled = true;
        }
    }
}
