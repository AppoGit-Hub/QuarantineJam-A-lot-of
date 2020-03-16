using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    [SerializeField] private GameObject DeathParticule;
    [SerializeField] private SoundSpawner SS;

    public void Kill()
    {        
        if (this.gameObject != null)
        {
            Instantiate(DeathParticule, this.transform.position, Quaternion.identity, GameManager.Instance.ParticuleHolder);

            SS.Spawn(this.transform.position);

            /*

            GameObject g = new GameObject();
            g.transform.position = this.transform.position;
            AudioSource As = g.AddComponent<AudioSource>();
            As.clip = DeathSound;
            As.Play();
           
            */

            DeathEvent de = new DeathEvent();
            de.DeadObject = this.gameObject;

            GameManager.Instance.ReportEvent(this.gameObject, de);

            Destroy(this.gameObject);            
        }       
    }
}
