using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(int health)
    {
        _slider.maxValue= health;
        _slider.value = health;
    }

    public void SetHealth(int health)
    {
        _slider.value = health;
    }
}
