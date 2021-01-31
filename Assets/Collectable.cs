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
    public GameObject messageTemplate;
    public string messageString;
    public Sprite shellSprite;

    private GameObject messageObject;
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

    private void Awake()
    {
        GameManager.Instance.collectables.Add(gameObject);
    }

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

                if (!messageTemplate)
                {
                    Debug.LogWarning("No message template in collectable");
                }
                else
                {
                    GameObject displayMessage = GameObject.Instantiate(messageTemplate, transform, false);
                    displayMessage.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    displayMessage.transform.localPosition = new Vector3(0.0f, -6.0f, -1.0f);
                    displayMessage.GetComponentInChildren<UnityEngine.UI.Text>().text = messageString;
                    messageObject = displayMessage;
                }
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
                transform.localPosition = Vector2.Lerp(startingPosition, destinationObject.transform.localPosition, 1);
                transform.localScale = Vector2.Lerp(endingScale, startingScale, 1);
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
                transform.localScale = Vector2.Lerp(endingScale, clearingScale, 1);
                GameManager.Instance.collectables.Remove(gameObject);
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
                Destroy(messageObject);
            }
            else
            {
                movementState = MovementState.IsMoving;
                Destroy(messageObject);
            }
        }

        GameObject player = GameManager.Instance.player;
        if (player)
        {
            PlayerMovement movement = player.GetComponent<PlayerMovement>();
            movement.EnableInput();
        }
    }

    public void TransformIntoShell(int range)
    {
        float min = range * 1.0f;
        float max = min + 0.5f;
        float randomTime = Random.Range(min, max);
        Invoke("TransformNow", randomTime);
    }

    private void TransformNow()
    { 
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        if (sprite)
        {
            sprite.sprite = shellSprite;
        }
        else
        {
            Debug.LogWarning("No shell sprite in collectable");
        }
    }
}
