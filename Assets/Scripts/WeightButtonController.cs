using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightButtonController : MonoBehaviour
{
    public DoorController door;
    public Animator animator;
    public TimeManager timeManager;
  
    // Start is called before the first frame update
    void Start()
    {
      
        timeManager = TimeManager.instance;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("ButtonDown");
        door.OpenDoor();
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetTrigger("ButtonUp");
        door.CloseDoor();
    }
}
