using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 Target
    {
        get
        {
            return (GameManager.Instance.PlayerInstance == null) ?
                Vector3.up :
                GameManager.Instance.PlayerInstance.transform.position;
        }
    }
    
    [SerializeField] [Range(5, 50)] private float Range;
    private void Update()
    {
        this.transform.position = new Vector3(Target.x, Target.y + Range, Target.z);
    }
}
