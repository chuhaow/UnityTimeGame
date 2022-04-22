using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject Prefab;
    public Camera cam;
    public GameObject firePoint;
    public float speed = 100;
    public static int amountOfProjectiles;

   // RaycastHit hit = new RaycastHit();
    
    // Start is called before the first frame update
    void Start()
    {
       // firePoint = cam.ViewportToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2));
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F)&&amountOfProjectiles>0)
        {
           // firePoint = cam.ViewportToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2));
            amountOfProjectiles--;
            GameObject projectile = Instantiate(Prefab, firePoint.transform.position, Quaternion.LookRotation(firePoint.transform.forward));
           // projectile.transform.LookAt(firePoint);
            projectile.GetComponent<Rigidbody>().velocity = firePoint.transform.forward* speed;
        }
    }
}
