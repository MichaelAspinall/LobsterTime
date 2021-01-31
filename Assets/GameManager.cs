using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : GenericSingletonClass<GameManager>
{
    public GameObject radioManager;
    public GameObject player;

    public AudioSource[] audioSources;

    int currentBuoy = 0;
    public List<GameObject> buoys;

    public List<GameObject> collectables;

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

    public void HitBuoy(GameObject buoy)
    {
        if (currentBuoy > 0)
        {
            audioSources[currentBuoy - 1].Stop();
        }
        if (currentBuoy < audioSources.Length)
        {
            audioSources[currentBuoy].Play();
        }

        currentBuoy++;
        buoys.Remove(buoy);

        if (currentBuoy == 6)
        {
            TransformCollectables();
        }
    }

    public void TransformCollectables()
    {
        int i = 3;
        foreach (GameObject collectableObject in collectables)
        {
            Collectable collectable = collectableObject.GetComponent<Collectable>();
            if (collectable)
            {
                collectable.TransformIntoShell(i);
                i++;
            }
        }
    }
};