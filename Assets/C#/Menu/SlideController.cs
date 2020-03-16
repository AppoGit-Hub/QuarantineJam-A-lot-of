using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideController : MonoBehaviour
{
    [SerializeField] private Slider Slider;
    [SerializeField] private Transform Panel;

    private int Width = 12360;

    public void ValueChanged(float n)
    {
        Panel.transform.localPosition = new Vector3(-(Width * n), 0, 0);
    }

    private void Update()
    {
        ValueChanged(Slider.value);
    }
}
