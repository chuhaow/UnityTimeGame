using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController Controller;
    public float speed = 12f;
    public float gravity = -9.89f;
    public float jumpHeight = 3f;
    Vector3 velocity;
    public LayerMask JumpAbleMask;
    public float groundDistance;
    public Transform groundCheck;
    public bool isGrounded;
    public bool isTimeBody;
    TimeManager t;
    public float LenghtOfRayMod;
    float AngleOfFloor;
    Vector3 HitNormal;
    public float SlidingSpeed;
    public bool _isSliding;
    public float castSphereThickness;
    float hitDistance;
    // Start is called before the first frame update
    void Start()
    {
       // groundDistance = Controller.bounds.extents.y;
        Debug.Log(groundDistance);
        t = TimeManager.instance;
        
       // Time.timeScale = 0;
    }

    // Update is called once per frame
   
    void Update()
    {
        _isSliding = isSliding();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, JumpAbleMask);
        //isTimeBody = Physics.CheckSphere(groundCheck.position, groundDistance, TimeBodyMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -3f;
        }
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
      
        Vector3 move = transform.right * Horizontal + transform.forward * Vertical;
        if (isSliding()==true)
        {
           
            move.x += (1f - HitNormal.y) * HitNormal.x * SlidingSpeed;
            move.z += (1f - HitNormal.y) * HitNormal.z * SlidingSpeed;
        }

        Controller.Move(move*speed*Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
       Controller.Move(velocity * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            switch (t.IsTimeStopped)
            {
                case true:
                    t.TimeResume();
                    break;
                case false:
                    t.ZaWarudo();
                    break;

            }
        }

      
    }



    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position+Vector3.down*hitDistance, castSphereThickness);


    }
    bool isSliding()
    {
        Ray ray = new Ray(transform.position, -Vector3.up);
        RaycastHit hit;
        
        if(Physics.SphereCast(transform.position,castSphereThickness,Vector3.down,out hit,3,JumpAbleMask))
        {

            // Destroy(hit.collider.gameObject);
            hitDistance = hit.distance;
            HitNormal = hit.normal;
            AngleOfFloor = Vector3.Angle(hit.normal, Vector3.up);
            Debug.Log(AngleOfFloor);
            if (AngleOfFloor >= Controller.slopeLimit)
            {
                Debug.Log("Is Sliding");
                return true;
            }
            else
            {
                Debug.Log("Not Sliding");
                return false;
            }
        }

        Debug.Log("Nothing Hit");
        return false;
    }

}
