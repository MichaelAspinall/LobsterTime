//Created 1/29/2021 Michael Aspinall
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //setting variables to public makes them visible in the editor, that is where speed gets set
    private float currentSpeed = 0.0f;
    public float maxSpeed = 0.01f;
    public float accelSpeed;
    public float decaySpeed;

    public float turnSpeed;

    private bool isInputDisabled;

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
        float forwardInput = Input.GetAxis("Vertical");
        if ((forwardInput == 0 && currentSpeed != 0) || isInputDisabled)
        {
            float decay = Mathf.Min(decaySpeed, Mathf.Abs(currentSpeed));
            currentSpeed = Mathf.Sign(currentSpeed) * (Mathf.Abs(currentSpeed) - decay);
        }
        else if (forwardInput > 0)
        {
            float targetSpeed = currentSpeed + accelSpeed;
            currentSpeed = Mathf.Min(targetSpeed, maxSpeed);
        }
        else if (forwardInput < 0)
        {
            float targetSpeed = currentSpeed - accelSpeed;
            currentSpeed = Mathf.Max(targetSpeed, -maxSpeed);
        }

        transform.Rotate(0.0f, 0.0f, -Input.GetAxis("Horizontal") * turnSpeed);
        if (currentSpeed != 0)
        {
            transform.position = new Vector3(transform.position.x + transform.up.x * currentSpeed * Time.deltaTime, transform.position.y + transform.up.y * currentSpeed * Time.deltaTime, 0.0f);
        }

    }

    public void DisableInput()
    {
        isInputDisabled = true;
    }

    public void EnableInput()
    {
        isInputDisabled = false;
    }
}
