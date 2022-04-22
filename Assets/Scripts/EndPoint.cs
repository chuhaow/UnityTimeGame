// CLASS: Audio
//
// Author: Chu Hao Wen
//
// REMARKS: The end of the level point
//
//-----------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    public InGameMenus GameMenus;
    private void Start()
    {
        GameMenus = InGameMenus.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(SceneManager.GetActiveScene().buildIndex != 3)
            {
                GameMenus.enableNextLevelScreen();
            }
            else
            {
                GameMenus.enableEndScreen();
            }
        }
    }
}
