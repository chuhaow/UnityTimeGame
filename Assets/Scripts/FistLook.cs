//------------------------------------------------------
// Author: Chu Hao Wen
//
// PURPOSE:    Orients the hands
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FistLook : MonoBehaviour
{
    public Transform cam;
  
    public float distance;
    // Start is called before the first frame update
    void Start()
    {

        if (transform.localPosition.x > 0)  //Make sure that the hands face forward
        {
            Vector3 Scale = transform.localScale;

            Scale.x *= -1;

            transform.localScale = Scale;
        }
       

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - (cam.position+cam.forward*distance));
    }
}
