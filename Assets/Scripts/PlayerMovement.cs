//Created 1/29/2020 Michael Aspinall
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Using a Ridgidbody isn't strictly nessessary, It just makes it easier to hand off collision detection to Unity
    Rigidbody2D boatRB;
    //setting variables to public makes them visible in the editor, that is where speed gets set
    public float speed;
    //player GameObject also set in editor
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        boatRB = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //I'm using the Unity Input Manager to make this a bit more simple
    //Find it under Project Settings
    void Update()
    {
        //This is just standard, currently does not affect the sprite.
        Vector3 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movement.Normalize();

        boatRB.velocity = movement * speed;
    }
}
