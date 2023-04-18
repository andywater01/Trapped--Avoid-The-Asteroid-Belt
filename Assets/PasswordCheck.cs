using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PasswordCheck : MonoBehaviour
{
    public Text passwordText;

    public void passwordButton() //Function for when button is pressed to enter password
    {
        if (passwordText.text == "4239")
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
