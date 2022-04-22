using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFist : MonoBehaviour
{
    public Camera cam;
    public GameObject FistPrefab;
    public int AmountOfFistSpawned;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < AmountOfFistSpawned; i++)
        {
            Vector3 p = RandomCircle(transform.position, 0.5f);
            Instantiate(FistPrefab, p, Quaternion.Euler(0f, 180f, 0f));
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
