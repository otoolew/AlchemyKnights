using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoLights : MonoBehaviour {

    public float duration = 1.0F;
    public Color color0 = Color.red;
    public Color color1 = Color.blue;
    public Light lt;
    public bool isActive;
    private float timer;
    private float colorChangeRate = 1;
    void Start()
    {
        lt = GetComponent<Light>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (isActive)
        {
            lt.intensity = 200;
            if (timer >= colorChangeRate)
            {
                timer = 0;
                color0 = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                color1 = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            }

            float t = Mathf.PingPong(Time.time, duration) / duration;
            lt.color = Color.Lerp(color0, color1, t);
        }
        else
        {
            lt.intensity = 0;
        }

    }
}
