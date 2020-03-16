using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Health))]
public class DamageTaker : MonoBehaviour
{
    [Header("Damage Parameters")]    
    [SerializeField] private Health Health;
    [SerializeField] private Armor Armor;

    [Header("On Death")]
    [SerializeField] private DeathManager DM;

    [Header("Stat")]
    [SerializeField] private PlayerBulletTaken PBT;


    private float GetMutiplicatorReduction
    {
        get
        {
            return 1;
        }
    }

    public void TakeDamage(float d)
    {
        float ArmorReduction = Armor.Reduction * GetMutiplicatorReduction;
        float DamageTaken = d * ArmorReduction;

        Health.Value -= DamageTaken;

        if (Health.Value <= 0)
            DM.Kill();

        PBT.Add(1);
    }
}
