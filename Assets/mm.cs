using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mm : MonoBehaviour
{
    public GameObject pause;
    public void move() 
    {
        //pause_menu.SetActive(false);
        SceneManager.LoadSceneAsync(1);
        
    }
    public void moveback()
    {
        
        SceneManager.LoadSceneAsync(0);

    }
    public void resumee()
    {

        Time.timeScale = 1f;
        pause.SetActive(false);
        SceneManager.LoadSceneAsync(1);

    }
    public void nextlevel()
    {

        
        SceneManager.LoadSceneAsync(2);

    }



}
