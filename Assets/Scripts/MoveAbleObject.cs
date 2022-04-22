using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAbleObject : MonoBehaviour
{
    
    public Transform cam;
    public Vector3 Location;
    public bool isHeld;
    public float distance;
 
    public Rigidbody rb;
    public float smooth;
    public TimeManager timeManager;
    public TimeBody timeBody;
    // Start is called before the first frame update
    void Start()
    {
        timeBody = GetComponent<TimeBody>();
        cam = Camera.main.transform;
        timeManager = TimeManager.instance;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isHeld)
        {
           
            transform.position = Vector3.Lerp(transform.position, cam.position + cam.forward * distance, Time.deltaTime * smooth);
           
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else if(!isHeld&&!timeManager.IsTimeStopped)
        {
           
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    public void Pickup()
    {
        Debug.Log("Pickup");
        timeBody.isStopped = false;
        timeBody.enabled = false;
        rb.useGravity = false;
        transform.parent = cam;
        isHeld = true;
        gameObject.layer = 0;
    }

    public void Drop()
    {
        timeBody.enabled = true;
        rb.useGravity = true;
        transform.parent = null;
        isHeld = false;
        gameObject.layer = 11;
    }

  
}
