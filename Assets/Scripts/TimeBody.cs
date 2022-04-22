using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody),typeof(MoveAbleObject))]
// CLASS: TimeBody
//
// Author: Chu Hao Wen
//
// REMARKS: Allows a object to be frozen in Time
//
//-----------------------------------------
public class TimeBody : MonoBehaviour
{
    public TimeManager timemanager;
    public bool CanBeAffected ;
    public Rigidbody rb;
    public float TimeTillFreeze;
    public bool isStopped ;
    public Vector3 RecordedDirection;
    public float RecordedMagnitude;
    public float totalForce;
    public Vector3 avgPosition;
    public Vector3 DirectionOfForce;
    public MoveAbleObject pickup;
    public int amountOfHits;
    public static float MAX_FORCE = 140f;   
    // Start is called before the first frame update

    void Start()
    {
        pickup = GetComponent<MoveAbleObject>();
        timemanager = TimeManager.instance; //get a instace of the TimeManager
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeTillFreeze -= Time.deltaTime;   //Used for objects that just spawned, only for knifes so they travel a little bit before stopping if thrown in stopped time
        
        if (TimeTillFreeze <= 0)
        {
           CanBeAffected = true;

        }

        if (CanBeAffected && timemanager.IsTimeStopped&&!isStopped)
        {
          
            if(RecordedDirection == Vector3.zero && RecordedMagnitude == 0){
              
                RecordedDirection = rb.velocity.normalized; //Record the current direction and maginitude
                RecordedMagnitude = rb.velocity.magnitude;
            }
           
            rb.constraints = RigidbodyConstraints.FreezeAll;    //Freeze the object
          

            isStopped = true;
        }
     
        if (!timemanager.IsTimeStopped&&isStopped)
        {
            TimeResume();
        }
        if(totalForce != 0 && !timemanager.IsTimeStopped)   //Check if there is force to be applied
        {
            ApplyForce();
        }
      
    }


    //------------------------------------------------------
    // TimeResume
    //
    // PURPOSE:    let the object move again and reapply forces from before frozen time
    //------------------------------------------------------
    public void TimeResume()
    {
        rb.constraints = RigidbodyConstraints.None;
        isStopped = false;
       
        rb.velocity = RecordedDirection * RecordedMagnitude;    // Add the direction and magnitude back from before frozen time
    }

    //------------------------------------------------------
    // ApplyFoce
    //
    // PURPOSE:    Apply force that was accumalted when time froze
    //------------------------------------------------------
    void ApplyForce()
    {
        avgPosition /= amountOfHits;    //Average out the position to send object when time resumes
        DirectionOfForce = transform.position - avgPosition;    
        Debug.DrawRay(transform.position, DirectionOfForce, Color.blue);
        
        if (totalForce != 0)
        {
            if(totalForce > MAX_FORCE)
            {
                totalForce = MAX_FORCE;
            }
            rb.AddForceAtPosition(DirectionOfForce * totalForce, avgPosition, ForceMode.Impulse);
        }
        avgPosition = Vector3.zero;
        DirectionOfForce = Vector3.zero;
        totalForce = 0;
        amountOfHits = 0;
    }


    //------------------------------------------------------
    // accumlateForce
    //
    // PURPOSE:    Update the amount of force accumlated during frozen time
    // PARAMETERS:
    //     amount - amount of force
    //     point - where the force was applied
    //------------------------------------------------------
    public void accumulateForce(float amount, Vector3 point)    //Add force during stoped time
    {
        
        avgPosition += point;

        amountOfHits++;
       
        totalForce += amount;

    }


}
