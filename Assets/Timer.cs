using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    UnityEngine.UI.Slider _slider;

    private void Start()
    {
        _slider = GetComponent<UnityEngine.UI.Slider>();
    }
    void Update()
    {
        _slider.value -= Time.deltaTime;
    }
}
