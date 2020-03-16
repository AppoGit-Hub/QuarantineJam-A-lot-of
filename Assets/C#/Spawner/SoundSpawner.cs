using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject SoundPrefab;
    [SerializeField] private AudioClip Sound;

    public void Spawn(Vector3 pos)
    {
        GameObject s = Instantiate(SoundPrefab, pos, Quaternion.identity, GameManager.Instance.HolderManager.SoundHolder);

        AudioSource As = s.GetComponent<AudioSource>();
        As.clip = Sound;
        As.Play();
    }
}
