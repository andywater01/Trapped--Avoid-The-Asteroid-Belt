using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image HealthBar;

    public Sprite Hearts0;
    public Sprite Hearts1;
    public Sprite Hearts2;
    public Sprite Hearts3;
    public GameObject Restart;
    public int Health = 3;

    public AudioSource crash;

    private void OnCollisionEnter2D(Collision2D collision) // Checks collision with asteroid
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            CheckHealth();
            crash.Play();
        }
    }

    void CheckHealth() // Checks what current health is and subtracts 1
    {
        if (Health == 3)
        {
            HealthBar.sprite = Hearts2;
            Health--;
        }
        else if (Health == 2)
        {
            HealthBar.sprite = Hearts1;
            Health--;
        }
        else if (Health == 1)
        {
            HealthBar.sprite = Hearts0;
            Health--;
            Debug.Log("Game Over");
            Restart.SetActive(true);
        }
    }

    public void SetHealth(int health) //Function to Set Health
    {
        Health = health;
    }

    public int GetHealth() // Function to Retrieve the Health Value
    {
        return Health;
    }
}
