// Author: Chu Hao Wen
//
// Purpose: Holds all the things that can happen in a animation of the punch
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationEvents : MonoBehaviour
{
    public LayerMask layerMask;
    public AudioManager AM;
    public static float REACH = 2.5f;   
    public GameObject Hitmarker;
    public Camera cam;
    private void Start()
    {
        //AM = AudioManager.instance; 
    }
    //------------------------------------------------------
    // DetectHit
    //
    // PURPOSE:    Checks if you are hitting a object during a frame
    // PARAMETERS:
    //     PunchForce - The amount of force to apply to the object hit
    //------------------------------------------------------
    public void DetectHit(float PunchForce)
    {

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);   //Cast a ray from the camera forward
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, REACH, layerMask))    //If we hit something within the reach and is on the LayerMask that can be hit
        {
          
            hit.collider.gameObject.GetComponent<TimeBody>().accumulateForce(PunchForce, hit.point);    //Provide force to the object where the ray hit the collider
            Instantiate(Hitmarker, hit.point, Quaternion.identity);     //Create a hit marker
        }

    }
}
