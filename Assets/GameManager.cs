using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : GenericSingletonClass<GameManager>
{
    public GameObject radioManager;

    int currentBuoy = 0;
    public List<GameObject> buoys;

    public GameObject GetCurrentBuoy()
    {
        foreach (GameObject buoyObject in buoys)
        {
            BuoyScript buoy = buoyObject.GetComponent<BuoyScript>();
            if (buoy && buoy.buoyNumber == currentBuoy)
            {
                return buoyObject;
            }
        }
        return null;
    }

    public void HitBuoy()
    {
        currentBuoy++;
    }
};