using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider mSlider;
    public BaseState player;
    // Start is called before the first frame update
    void Start()
    {
        mSlider.value = 1f;
        mSlider.maxValue = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        mSlider.value = player.HP / 100f;
    }
}
