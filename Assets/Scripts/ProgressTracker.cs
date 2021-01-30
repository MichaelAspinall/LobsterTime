using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    public int buoysHit;
    public int transmissionsHit;

    // Start is called before the first frame update
    void Start()
    {
        buoysHit = 0;
        transmissionsHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Transmission")
        {
            transmissionsHit++;
        }
    }
}
