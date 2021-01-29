using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDispacher : MonoBehaviour
{
    //Reference UI elements here in order to call functions on them

    //We want to access the progress tracker's data
    //so we grab the player get component
    public GameObject player;
    ProgressTracker pTracker;

    //will compare values for buoys and transmissions to previous frame
    //If I had time I would figure out Unity's event system because this is bad
    int oldBuoys;
    int oldTransmissions;

    //Check to see if

    // Start is called before the first frame update
    void Start()
    {
        //access the progress tracker
        pTracker = player.GetComponent <ProgressTracker> ();

        oldBuoys = 0;
        oldTransmissions = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(oldBuoys != pTracker.buoysHit)
        {
            oldBuoys = pTracker.buoysHit;
            CollectedBuoy();
        }
        if (oldTransmissions != pTracker.transmissionsHit)
        {
            oldTransmissions = pTracker.transmissionsHit;
            GotTransmission();
        }
    }

    //Handel logic for hitting a buoy here
    void CollectedBuoy()
    {
        switch (oldBuoys)
        {
            case 1:
                Debug.Log("Case 1 hit in CollectedBuoy()");
                break;
            case 2:
                Debug.Log("Case 2 hit in CollectedBuoy()");
                break;
            case 3:
                break;
            default:
                Debug.Log("Defualt case hit in CollectedBuoy()");
                break;
        }
    }


    //Handel logic for getting a radio transmission here
    void GotTransmission()
    {
        switch (oldTransmissions)
        {
            case 1:
                Debug.Log("Case 1 hit in GotTransmission()");
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                Debug.Log("Defualt case hit in GotTransmission()");
                break;
        }
    }
}
