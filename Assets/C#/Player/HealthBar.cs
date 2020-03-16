using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public RectTransform Heath;

    public void SetHealthBar(Union proportion)
    {
        this.Heath.localScale = new Vector3(proportion.Value, 1, 1); 
    }
}
