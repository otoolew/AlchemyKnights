using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToxicManager : MonoBehaviour
{
    public Slider[] toxicSliders;
    public float reduceAmountPerSec = 5;
    private float timer;
    private float tickRate = 1;
    public float halfLife =2;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= tickRate)
        {
            DecaySliders();
        }
    }
    // Can be a collection or properly a Scripted Object
    // Decay Sliders will be no longer a constant but a half life formula
    void DecaySliders()
    {
        // Drug HalfLife = 1HL - L = ActiveIngerdient/ 2
        timer = 0;
        foreach (Slider slider in toxicSliders)
        {
            slider.value -= reduceAmountPerSec;
        }

    }
    public void UpdateSlider(int slot)
    {
        timer = 0;
        toxicSliders[slot].value += 50;
    }
}