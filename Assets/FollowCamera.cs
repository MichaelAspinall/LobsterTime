using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform PlayerTransform;
    private Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //TODO
        transform.position = new Vector3(PlayerTransform.position.x + offset.x, PlayerTransform.position.y + offset.y, -10.0f);
    }
}
