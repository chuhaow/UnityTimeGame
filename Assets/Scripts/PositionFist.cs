using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFist : MonoBehaviour
{
    public Transform cam;
    public Transform target;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x > 0)
        {
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(cam.position + cam.forward * distance);

    }
}
