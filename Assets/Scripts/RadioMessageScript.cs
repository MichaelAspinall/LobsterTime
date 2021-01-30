using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioMessageScript : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        AddMessage(true, "TestMessage!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddMessage(bool fromPlayer, string message)
    {
        GameObject CurrentMessage = new GameObject("message");
        RectTransform rect = CurrentMessage.AddComponent<RectTransform>();
        rect.sizeDelta = new Vector2(300.0f, 65.0f);
        Text currentMessage = this.gameObject.AddComponent<Text>();
        currentMessage.text = message;
        CurrentMessage.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        Image textBackground = CurrentMessage.AddComponent<Image>();
        textBackground.color = new Color32(233,209,89,225);
        

        if (fromPlayer)
        {
            
        }
        else
        {
            
        }
    }
}
