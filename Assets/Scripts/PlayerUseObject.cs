using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerUseObject : MonoBehaviour
{
    public static float REACH = 2.5f;
    public TextMeshProUGUI textMeshProUGUI;

    Interactable interactable;
    private void Start()
    {
        textMeshProUGUI = GameObject.Find("Canvas").GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        DetectInteractable();
    }
    public void DetectInteractable()
    {


        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, REACH))
        {
           
           // Debug.Log(hit.collider.gameObject.name);


           interactable = hit.collider.gameObject.GetComponent<Interactable>();
            if (interactable != null)
            {
                textMeshProUGUI.enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Use();
                }
               
            }



        }
        else
        {
            NoInteractableDectected();
        }


    }

    void NoInteractableDectected()
    {
       interactable = null;
       textMeshProUGUI.enabled = false;
    }
}
