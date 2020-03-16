using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{
    public Health HeathOnFocus;
    [SerializeField] private HealthBar Bar;
    [SerializeField] private Text HealthText;
    
    private void Update()
    {
        OnHeathSet(HeathOnFocus.Value);        
    }
    public void OnHeathSet(float v)
    {
        float proportion = HeathOnFocus.Value / HeathOnFocus.MaxValue;
        Bar.SetHealthBar(new Union(proportion));
        HealthText.text = $"{HeathOnFocus.Value}/{HeathOnFocus.MaxValue}";
    }

    public void ResetHealth()
    {
        HealthText.text = "XX / XX";
        Bar.Heath.localScale = new Vector3(1, 1, 1);
    }
}
