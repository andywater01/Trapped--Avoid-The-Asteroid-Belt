using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PasswordCheck : MonoBehaviour
{
    public Text passwordText;
    public GameObject WrongPasswordObj;

    public void Update()
    {
        if (passwordText.text == "4239")
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
                SceneManager.LoadScene("GameScene");
        }
    }


    public void passwordButton() //Function for when button is pressed to enter password
    {
        if (passwordText.text == "4239")
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            StartCoroutine(WrongPassword());
        }
    }


    public IEnumerator WrongPassword()
    {
        WrongPasswordObj.SetActive(true);
        yield return new WaitForSeconds(2);
        WrongPasswordObj.SetActive(false);

        StopCoroutine(WrongPassword());
    }
}
