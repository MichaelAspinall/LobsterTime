//Created 1/29/2021 Michael Aspinall
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyScript : MonoBehaviour
{
    public int buoyNumber;
    public GameObject itemToSpawn;
    public GameObject desinationObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //2D collision handeler
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerState player = collision.gameObject.GetComponent<PlayerState>();
        if (player)
        {
            Debug.Log("Buoy Hit");
            SpawnCollectable();
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

        GameObject item = GameObject.Instantiate(itemToSpawn, radioCanvas.transform, false);
        Collectable collectable = item.GetComponent<Collectable>();
        if (!collectable)
        {
            Debug.LogWarning("Buoy is spawning a non-collectable item");
        }
        else
        {
            collectable.destinationObject = desinationObject;
        }
    }
}
