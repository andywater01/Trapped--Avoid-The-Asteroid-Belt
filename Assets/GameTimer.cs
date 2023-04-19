using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timer = 0.0f;
    public Slider slider;

    public GameObject YouWin;
    public AudioSource WinSound;

    // Update is called once per frame
    void Update() // Keeps track of time and sets the slider value
    {
        if (timer < 100.0f)
            timer += Time.deltaTime;

        slider.value = timer;

        if (timer >= 100.0f)
        {
            StartCoroutine(Win());
        }
    }


    public IEnumerator Win()
    {
        YouWin.SetActive(true);
        WinSound.Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("FinishScene");
        StopCoroutine(Win());
    }

    public bool hasWon()
    {
        if (YouWin.activeInHierarchy == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
