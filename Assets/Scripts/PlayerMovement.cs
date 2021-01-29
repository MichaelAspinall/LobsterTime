//Created 1/29/2021 Michael Aspinall
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    //setting variables to public makes them visible in the editor, that is where speed gets set
    public float speed;
    //player GameObject also set in editor

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    //I'm using the Unity Input Manager to make this a bit more simple
    //Find it under Project Settings
    void Update()
    {
        //This is just standard, currently does not affect the sprite.
        Vector3 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movement.Normalize();
        movement *= speed;
        transform.position = new Vector3(transform.position.x + movement.x,
            transform.position.y + movement.y, 0.0f);
    }
}
