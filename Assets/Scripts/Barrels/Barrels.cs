using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrels : MonoBehaviour
{
    [SerializeField] private LayerMask _earth;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            gameObject.SetActive(false);
        }
    }
}
