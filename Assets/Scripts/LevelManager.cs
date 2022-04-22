using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{

    public string[] Levels = new string[2];

    #region Singleton
    public static LevelManager instance;
    //public TimestopVFXController VFX;

    private void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    #endregion


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(Levels[1]);
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(Levels[2]);
        }
    }
}
