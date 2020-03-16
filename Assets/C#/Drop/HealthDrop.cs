using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    [SerializeField] private AudioSource AppearSound;
    [SerializeField] private AudioSource TookSound;
    
    public int Health = 30;


    private void Update()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        if (p == null) return;

        float d = Vector3.Distance(p.transform.position, this.transform.position);

        if (d <= 3)
        {
            p.GetComponent<Health>().AddHealth(Health);

            TookSound.Play();

            Destroy(this.gameObject);
        }
    }
}
