using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public Animator animator;
    public AudioManager AM;
    public Collider LeftCollider;
    public Collider RightCollider;
    public bool isSoundPlaying;
    public float timer;
    public GameObject AttackRushObject;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        AM = AudioManager.instance;
    
        skinnedMeshRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(transform.position, transform.forward,Color.red);
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
           
            animator.SetBool("isRightPunch", true);
        }
        else
        {
            
            animator.SetBool("isRightPunch", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           
            animator.SetBool("isLeftPunch", true);
        }
        else
        {
          
            animator.SetBool("isLeftPunch", false);
        }

        if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
        {
            timer += Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.Mouse0)==false && Input.GetKey(KeyCode.Mouse1)==false)
        {
            timer = 0;
        }
        if(timer >= 0.9)
        {
            if (!isSoundPlaying)
            {
                AM.PlaySound("Punch SFX");
                isSoundPlaying = true;
            }
            AttackRushObject.SetActive(true);
            skinnedMeshRenderer.enabled = false;
        }else if(timer == 0)
        {

            isSoundPlaying = false;
            AM.StopSound("Punch SFX");
            AttackRushObject.SetActive(false);
            skinnedMeshRenderer.enabled = true;
              
        }
    }



    public void enableLeftHitbox()
    {
        LeftCollider.enabled = true;
    }

    public void enableRightHitbox()
    {
        RightCollider.enabled = true;
    }

    public void disableLeftHitbox()
    {
        LeftCollider.enabled = false;
    }

    public void disableRightHitbox()
    {
        Debug.Log("Called");
        RightCollider.enabled = false;
    }
}
