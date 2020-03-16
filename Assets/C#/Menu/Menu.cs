using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    [Header("Instance")]
    [SerializeField] private GameObject Instance;

    public void SetActive(bool b)
    {
        Instance.SetActive(b);
    }
}
