using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrels : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision != null)
        {
            gameObject.SetActive(false);
        }
    }
}
