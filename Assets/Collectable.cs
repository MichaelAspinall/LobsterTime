using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementState
{
    IsGrowing,
    HasGrown,
    IsMoving,
    HasMoved,
    IsClearing,
    IsCleared
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

    private float clearTimeElapsed;
    public const float clearDurationSeconds = 0.3f;

    private Vector2 startingPosition;
    private Vector2 clearingScale;

    public float scaleUpAmount;

    // Start is called before the first frame update
    void Start()
    {
        startingScale = transform.localScale;
        endingScale = transform.localScale * scaleUpAmount;
        clearingScale = transform.localScale * 0.1f;
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
                transform.localPosition = Vector2.Lerp(startingPosition, destinationObject.transform.localPosition, moveTimeElapsed / moveDurationSeconds);
                transform.localScale = Vector2.Lerp(endingScale, startingScale, moveTimeElapsed / moveDurationSeconds);
                moveTimeElapsed += Time.deltaTime;
            }
            else
            {
                movementState = MovementState.HasMoved;
                transform.localPosition = destinationObject.transform.localPosition;
                transform.localScale = startingScale;
            }
        }

        if (movementState == MovementState.IsClearing)
        {
            if (clearTimeElapsed <= clearDurationSeconds)
            {
                transform.localScale = Vector2.Lerp(endingScale, clearingScale, clearTimeElapsed / clearDurationSeconds);
                clearTimeElapsed += Time.deltaTime;
            }
            else
            {
                movementState = MovementState.IsCleared;
                transform.localScale = clearingScale;
                Destroy(gameObject);
            }
        }

    }

    private void OnMouseDown()
    {
        if (movementState == MovementState.HasGrown)
        {
            if (destinationObject == null)
            {
                startingPosition = transform.localPosition;
                movementState = MovementState.IsClearing;
            }
            else
            {
                movementState = MovementState.IsMoving;
            }
        }

        GameObject player = GameManager.Instance.player;
        if (player)
        {
            PlayerMovement movement = player.GetComponent<PlayerMovement>();
            movement.EnableInput();
        }
    }
}
