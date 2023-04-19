using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Camera mainCam;
    public PlayerHealth ph;
    private bool canCollide = true;

    public BoxCollider2D collider1;
    public BoxCollider2D collider2;
    public BoxCollider2D collider3;
    public BoxCollider2D collider4;

    public CameraShake camShake;
    public GameTimer gTimer;

    public void Awake()
    {
        Cursor.visible = false; //Cursor Set to Invisible
        Cursor.lockState = CursorLockMode.Confined; //Locks cursor to boundaries of screen
    }

    //Gets Mouse Position and sets the players transform position to the mouse position.
    public void Update()
    {
        if (ph.GetHealth() > 0)
        {
            var mousePos = Input.mousePosition;
            this.transform.position = mainCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 100f));
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (gTimer.hasWon() == true)
        {
            this.gameObject.SetActive(false);
        }

    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (ph.GetHealth() > 0)
        {
            if (collision.gameObject.tag == "Asteroid" && canCollide)
            {
                StartCoroutine(CollisionHappened());
                Debug.Log("Hit");
                StartCoroutine(camShake.Shake(0.5f, 0.8f));
                
            }
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red; // Player dies
        }
        
    }

    public IEnumerator CollisionHappened() //Flashes Red when player collides with asteroid
    {
        canCollide = false;
        collider1.enabled = false;
        collider2.enabled = false;
        collider3.enabled = false;
        collider4.enabled = false;

        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.2f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.2f);

        collider1.enabled = true;
        collider2.enabled = true;
        collider3.enabled = true;
        collider4.enabled = true;
        canCollide = true;
        
        StopCoroutine(CollisionHappened());
    }


    

}
