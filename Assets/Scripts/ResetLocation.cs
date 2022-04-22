using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLocation : MonoBehaviour
{
    public CharacterController controller;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            controller.enabled = false;
            other.transform.position = other.GetComponent<SpawnLocation>().GetStartLocation();
            controller.enabled = true;
            Debug.Log("Return");
        }
        else if (other.GetComponent<SpawnLocation>().GetStartLocation() != null)
        {
            other.transform.position = other.GetComponent<SpawnLocation>().GetStartLocation();
        }

    }
}

