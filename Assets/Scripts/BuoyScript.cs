//Created 1/29/2021 Michael Aspinall
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuoyScript : MonoBehaviour
{
    public int buoyNumber;
    public GameObject itemToSpawn;
    public GameObject desinationObject;
    public GameObject messageTemplate;
    public string message;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.buoys.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //2D collision handeler
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        if (player)
        {
            Debug.Log("Buoy Hit");
            SpawnCollectable();
            GameManager.Instance.HitBuoy(gameObject);

            player.DisableInput();
            Destroy(transform.root.gameObject);
        }
    }
    private void SpawnCollectable()
    {
        GameObject radioCanvas = GameManager.Instance.radioManager;
        if (!radioCanvas)
        {
            Debug.Log("Cannot find radio canvas to spawn collectable");
            return;
        }

        if (itemToSpawn)
        {
            GameObject item = GameObject.Instantiate(itemToSpawn, radioCanvas.transform, false);
            Collectable collectable = item.GetComponent<Collectable>();
            if (!collectable)
            {
                Debug.LogWarning("Buoy is spawning a non-collectable item");
            }
            else
            {
                collectable.destinationObject = desinationObject;

                if (messageTemplate)
                {
                    GameObject displayMessage = GameObject.Instantiate(messageTemplate, item.transform, false);
                    displayMessage.transform.localScale = new Vector3(0.05f, 0.05f, 1.0f);
                    displayMessage.transform.localPosition = new Vector3(0.0f, -6.0f, -1.0f);
                    displayMessage.GetComponentInChildren<Text>().text = message;
                    collectable.messageObject = displayMessage;
                }
            }
        }
    }
}
