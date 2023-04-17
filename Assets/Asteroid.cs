using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private float Force = 50000.0f;
    private float RotSpeed = 50.0f;
    private float Scale = 4;

    // Start is called before the first frame update
    void Start()
    {
        Force = Random.Range(45000, 60000); //Sets the speed of the astroid to random amount
        RotSpeed = Random.Range(25, 50); //Sets rotation speed of asteroid to random amount
        Scale = Random.Range(3f, 6.5f); // Sets Scale of asteroid to random amount

        transform.localScale = new Vector3(Scale, Scale, 1.0f);
    }

    private void FixedUpdate()
    {
        //Adding the force and rotation to the asteroid
        GetComponent<Rigidbody2D>().AddForce(new Vector3(-1, 0, 0) * Force * Time.deltaTime, ForceMode2D.Force);
        transform.Rotate(0, 0, RotSpeed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destroyer")
        {
            Destroy(this.gameObject); // Destroys asteroid once it hits the destroyer game object
        }
    }
}
