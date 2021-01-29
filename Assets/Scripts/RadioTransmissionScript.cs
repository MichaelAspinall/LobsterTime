//Created 1/29/2021 Michael Aspinall
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTransmissionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Does more it less the exact same thing as the buoy
    //Could probably have made a parent class, didn't
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Transmission Hit");
        //What to do when contact is made with the buoy is handeled in the player script
        //So we just get rid of the object here
        if (collision.gameObject.tag == "Player")
        {
            Destroy(transform.root.gameObject);
        }
    }
}
