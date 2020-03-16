using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletTaken : MonoBehaviour
{
    public void Add(int n = 1)
    {
        GameManager.Instance.GameStat.BulletTakenPlayer += n;
    }
}
