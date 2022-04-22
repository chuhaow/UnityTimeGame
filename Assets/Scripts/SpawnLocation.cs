using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    public Vector3 Location;
    // Start is called before the first frame update
    void Start()
    {
        Location = transform.position;
    }

    public Vector3 GetStartLocation()
    {
        return Location;
    }
}
