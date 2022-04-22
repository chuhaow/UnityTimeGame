using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public SphereCollider _Collider;
    public FixedJoint fj;
    // Start is called before the first frame update
    void Start()
    {
       
        _Collider = GetComponent<SphereCollider>();
        Invoke("EnablePlayerJumpOn", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
      
        if (collision.gameObject.CompareTag("Object")&&fj==null)
        {
            Debug.Log("Connected");
            fj = gameObject.AddComponent<FixedJoint>();
            fj.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
        }
        
    }

   void EnablePlayerJumpOn()
    {
      
        gameObject.layer = 11; 
    }
}
