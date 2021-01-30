using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementState
{
    IsGrowing,
    HasGrown,
    IsMoving,
    HasMoved
}


public class Collectable : MonoBehaviour
{
    public GameObject destinationObject;
    private MovementState movementState = MovementState.IsGrowing;

    private float growTimeElapsed = 0;
    public const float growDurationSeconds = 0.5f;

    private Vector2 startingScale;
    private Vector2 endingScale;

    private float moveTimeElapsed;
    public const float moveDurationSeconds = 0.3f;

    private Vector2 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingScale = transform.localScale;
        endingScale = transform.localScale * 3;
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementState == MovementState.IsGrowing)
        {
            if (growTimeElapsed <= growDurationSeconds)
            {
                transform.localScale = Vector2.Lerp(startingScale, endingScale, growTimeElapsed / growDurationSeconds);
                growTimeElapsed += Time.deltaTime;
            }
            else
            {
                transform.localScale = endingScale;
                movementState = MovementState.HasGrown;
            }
        }

        if (movementState == MovementState.IsMoving)
        {
            if (moveTimeElapsed <= moveDurationSeconds)
            {
                transform.position = Vector2.Lerp(startingPosition, destinationObject.transform.position, moveTimeElapsed / moveDurationSeconds);
                transform.localScale = Vector2.Lerp(endingScale, startingScale, moveTimeElapsed / moveDurationSeconds);
                moveTimeElapsed += Time.deltaTime;
            }
            else
            {
                movementState = MovementState.HasMoved;
                transform.position = destinationObject.transform.position;
                transform.localScale = startingScale;
            }
        }
    }

    private void OnMouseDown()
    {
        if (movementState == MovementState.HasGrown)
        {
            movementState = MovementState.IsMoving;
        }
    }
}
