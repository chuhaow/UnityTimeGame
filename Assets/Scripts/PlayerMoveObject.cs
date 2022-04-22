using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveObject : MonoBehaviour
{
    public LayerMask layerMask;
    public bool canBePickedUp;
    public static float REACH = 2.5f;
    public GameObject ObjectPickedUp;
    public Camera cam;
    public Animator animator;
    public float rotationAmount;
    private void Start()
    {
        layerMask =LayerMask.GetMask("HasTimeBody");
    }
    private void Update()
    {

        if ( Input.GetKey(KeyCode.R))
        {
            DetectPickupAble();
            rotateObject();
        }
        else
        {
            DropObjecct();
        }
     
    }
    public void DetectPickupAble()
    {

       
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, REACH, layerMask)&&ObjectPickedUp==null)
        {
            animator.SetBool("isArmDown", true);
            Debug.Log(hit.collider.gameObject.name);
         
                hit.collider.gameObject.GetComponent<MoveAbleObject>().Pickup();
                ObjectPickedUp = hit.collider.gameObject;
            
           
            
        }
        

    }

    void rotateObject()
    {
        if (ObjectPickedUp != null)
        {
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                Debug.Log("Scrolling");
                Mathf.Lerp(ObjectPickedUp.transform.localRotation.x, Input.GetAxis("Mouse ScrollWheel"), Time.deltaTime);
                ObjectPickedUp.transform.Rotate(Input.GetAxis("Mouse ScrollWheel") * Vector3.right * Time.deltaTime * rotationAmount,Space.Self);
            }
        }
    }

    void DropObjecct()
    {
        if (ObjectPickedUp != null)
        {
            animator.SetBool("isArmDown", false);
            ObjectPickedUp.GetComponent<MoveAbleObject>().Drop();
            ObjectPickedUp = null;
        }
    }
}

