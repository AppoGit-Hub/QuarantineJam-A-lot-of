using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLimit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        DeathManager dm = collision.gameObject.GetComponent<DeathManager>();

        if (dm == null)
        {
            Destroy(collision.gameObject);
        }
        else
        {
            dm.Kill();
        }
    }
}
