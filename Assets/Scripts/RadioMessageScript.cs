using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioMessageScript : MonoBehaviour
{
    public GameObject playerMessageTemplate;
    public GameObject radioMessageTemplate;

    
    // Start is called before the first frame update
    void Start()
    {
        AddMessage(true, "TestMessage!");
        AddMessage(false, "Test Radio Message");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddMessage(bool fromPlayer, string message)
    {

        GameObject newMessage;
        Vector3 messagePos;

        if (fromPlayer)
        {
            newMessage = Instantiate(playerMessageTemplate, transform.position, transform.rotation);
            messagePos = new Vector3(0, 0, 0);
        }
        else
        {
            newMessage = Instantiate(radioMessageTemplate, transform.position, transform.rotation);
            messagePos = new Vector3(6, 0, 0);
        }
        newMessage.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform);
        newMessage.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        newMessage.transform.position = messagePos;
        newMessage.GetComponentInChildren<Text>().text = message;
    }
}
