using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private GameObject currentTarget;
    public float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green, 5.0f);

        GameObject currentBuoy = GameManager.Instance.GetCurrentBuoy();
        if (currentBuoy)
        {

            if (currentBuoy != currentTarget)
            {
                currentTarget = currentBuoy;
            }

            //transform.LookAt(currentTarget.transform, transform.up);
            Vector3 boatToBuoy = currentTarget.transform.position - gameObject.transform.parent.position;
            if (boatToBuoy.magnitude > maxDistance)
            {
                boatToBuoy.Normalize();
                boatToBuoy *= maxDistance;
            }

            transform.position = transform.parent.position + boatToBuoy;
            transform.rotation = Quaternion.identity;
        }
    }
}
