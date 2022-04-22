using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchDetect : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.up, Color.red);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("1");
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            print(hit.point);
            Instantiate(prefab, hit.point, Quaternion.identity);
        }
    }
}
