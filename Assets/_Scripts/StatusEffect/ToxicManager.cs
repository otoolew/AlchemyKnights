using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToxicManager : MonoBehaviour
{
    public Slider[] toxicSliders;
    public BlindStatusEffect BlindEffect;
    public ConfusionDebuff confusionDebuff;

    public SlowDebuff slow;
    public PoisonDebuff poison;
    public float reduceAmountPerSec = 5;
    private float timer;
    private float tickRate = 1;
    public float halfLife;
    public bool isBlind = false;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
            BlindEffect.ApplyBlind();
        if (Input.GetKeyDown(KeyCode.P))
            poison.ApplyEffect();



        timer += Time.deltaTime;
        if (timer >= tickRate)
        {
            DecaySliders();
        }
        CheckToxicInteractions();
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
        //timer = 0;
        toxicSliders[slot].value += 50;
    }

    public void TakePotion(int slot)
    {
        switch (slot)
        {
            case 0:
                //Debug.Log("Took Red Potion");
                UpdateSlider(slot);
                break;
            case 1:
                //Debug.Log("Took Blue Potion");
                UpdateSlider(slot);
                break;
            case 2:
                //Debug.Log("Took Green Potion");
                UpdateSlider(slot);
                break;
            case 3:
                //Debug.Log("Took Yellow Potion");
                UpdateSlider(slot);
                break;
            default:
                break;
        }
    }
    // Can be implemented better but its like 2:38 AM
    public void CheckToxicInteractions()
    {
        // Red Toxic Check
        if (toxicSliders[0].value > 50)
        {
            slow.ApplyEffect();
        } 
        // Blue Toxic Check
        if (toxicSliders[1].value > 90)
        {
                confusionDebuff.ApplyEffect();
        }
        // Green Toxic Check
        if (toxicSliders[2].value > 90)
        {
            BlindEffect.ApplyBlind();
        }
        // Yellow Toxic Check
        if (toxicSliders[3].value > 90)
        {
            poison.ApplyEffect();
        }

    }
}