using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;

    private StopWatch Waiter = new StopWatch();

    private bool IsDisable = false;


    void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(this.transform.forward * 1000);

        this.Waiter.SetWait(Destroy, 120, 0, true);
        
    }

    private void Update()
    {
        Waiter.Update();
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageTaker dt = collision.transform.GetComponent<DamageTaker>();

        if (dt != null && collision.transform.tag != "Enemy")
        {
            if (IsDisable)
            {

            }
            else
            {
                dt.TakeDamage(10);

                print($"DAMAGE {collision.transform.name}");
            }            
        }

        /*
        
        if (collision.transform.tag == "Shield")
        {
            this.GetComponent<Renderer>().material.color = Color.black;
        }

        */

        /*

        if (collision.transform.tag == "Shield")
        {
            Destroy(this.gameObject);
        }

        */
    }

    private void OnCollisionStay(Collision collision)
    {
        /*
        
        if (collision.transform.tag == "Floor")
        {
            Destroy(this.GetComponent<Rigidbody>());
            Destroy(this.GetComponent<MeshCollider>());
        }

        */

        if (collision.transform.tag == "Floor" || collision.transform.tag == "Shield")
        {
            IsDisable = true;
        }
    }
}
