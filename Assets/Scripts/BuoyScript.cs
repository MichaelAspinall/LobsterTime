//Created 1/29/2021 Michael Aspinall
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuoyScript : MonoBehaviour
{
    public static Dictionary<string, string> dialogues = new Dictionary<string, string>()
    {
        {"Radio", "Good morning, it’s 7:45am...a cold and sunny day today with a high of 27 degrees..." },
        {"Intro", "Been up since 3am - the witching hour - odd things occur...but it’s daytime that worries me today."},
        {"Lobster1", "Fishing keeps me sane on days like this..."},
        {"Lunchbox", "No way...my lunch box! Knocked it overboard last week...can’t believe last time I saw Greg was at Maria’s Subs...he got steak & cheese."},
        {"Lobster2", "I always knew I wanted to make a living as a fisherman...and it’s good money if you work hard" },
        {"Whiskey", "Smells just like that cheap whiskey we’d steal and drink in school...he always went too hard. I’ll make a toast to a friend lost too soon!"},
        {"Tape", "It can’t be my tape! Greg missed that show and borrowed my bootleg the next day. I never asked him why he didn’t make it...he was struggling already."},
        {"Lobster3", "I’ve got to ride out the storm of these last couple days... "},
        {"Ending", "Tim, are you there? Come back to shore...we need you here. It’s time to say goodbye." }
    };

    public int buoyNumber;
    public GameObject itemToSpawn;
    public GameObject desinationObject;
    public GameObject messageTemplate;
    public string messageName;

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
                collectable.messageTemplate = messageTemplate;

                string message = dialogues[messageName];
                if (message.Length == 0)
                {
                    message = "Invalid Message: " + messageName;
                }

                collectable.messageString = message;
            }
        }
    }
}
