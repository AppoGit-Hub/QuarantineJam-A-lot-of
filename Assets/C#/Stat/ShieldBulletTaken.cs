using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBulletTaken : MonoBehaviour
{
    public void Add(int n = 1)
    {
        GameManager.Instance.GameStat.BulletTakenShield += n;
    }
}
