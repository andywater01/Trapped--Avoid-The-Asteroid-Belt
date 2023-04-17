using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float timer = 0.0f;
    public Slider slider;

    // Update is called once per frame
    void Update() // Keeps track of time and sets the slider value
    {
        if (timer < 100.0f)
            timer += Time.deltaTime;

        slider.value = timer;
    }
}
