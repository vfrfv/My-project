using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtaMissile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            Destroy(gameObject);
        }
    }
}
