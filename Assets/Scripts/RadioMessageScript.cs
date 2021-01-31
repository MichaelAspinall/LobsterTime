using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioMessageScript : MonoBehaviour
{
    public GameObject playerMessageTemplate;
    public GameObject radioMessageTemplate;


    GameObject[] messageList;
    float[] messageTime;
    int numMessages;
    
    // Start is called before the first frame update
    void Start()
    {
        messageList = new GameObject[10];
        messageTime = new float[10];
        numMessages = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //If we have messages, cound down from the top of the list
        if(numMessages > 0)
        {
            for (int i = numMessages - 1; i >= 0; i--)
            {
                //Add to the list the time that that message has been on screen
                messageTime[i] += Time.deltaTime;
                if (messageTime[i] > 15.0f)
                {
                    //If it has been on screen for more than 15 seconds get rid of it
                    Destroy(messageList[numMessages - 1]);
                    messageTime[numMessages - 1] = 0;
                    numMessages--;
                }
                
            }
            //Display the messages in the bottom right corner in order from oldest to newest going down
            for (int i = 0; i < numMessages; i++)
            {
                messageList[i].transform.position = new Vector3(6, -3 + i, -1);
            }
        }
    }

    //Adds a messages
    public void AddMessage(bool fromPlayer, string message)
    {

        GameObject newMessage;

        if (fromPlayer)
        {
            newMessage = Instantiate(playerMessageTemplate, transform.position, transform.rotation);
        }
        else
        {
            newMessage = Instantiate(radioMessageTemplate, transform.position, transform.rotation);
        }
        newMessage.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform);
        newMessage.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
        newMessage.GetComponentInChildren<Text>().text = message;
        if(numMessages > 0)
        {
            for (int i = numMessages; i > 0; i--)
            {
                messageList[i] = messageList[i - 1];
            }
        }
        
        messageList[0] = newMessage;
        messageTime[0] = 0.0f;
        numMessages++;
    }
}
