// CLASS: Door
//
// Author: Chu Hao Wen
//
// REMARKS: Controls animation for a door
//
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
  
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void OpenDoor()
    {
        animator.SetBool("isDoorOpen", true);
    }

    public void CloseDoor()
    {
        animator.SetBool("isDoorOpen", false);
    }

}
