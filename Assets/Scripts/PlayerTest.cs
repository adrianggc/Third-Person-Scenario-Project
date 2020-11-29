using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private float speed = 5f;
    private float turnspeed = 70.0f;


    private float horizontalInput;
    private float forwardinput;
    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        forwardinput = Input.GetAxis("Vertical");
        //Move the Vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardinput);
        //Rotates the car based in the horizontal input
        transform.Rotate(Vector3.up * turnspeed * horizontalInput * Time.deltaTime);
        /*speed++;
        if (speed <= 20.0f)
        {
            speed = 20f;
        }*/
    }
}
