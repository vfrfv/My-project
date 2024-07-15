using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrels : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out Player player) || collision.TryGetComponent(out Enemy enemy))
        {
            gameObject.SetActive(false);
        }
    }
}
