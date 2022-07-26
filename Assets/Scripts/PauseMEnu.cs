using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMEnu : MonoBehaviour
{

    public static bool GamePaused = false;   

    public GameObject PauseMenuUI;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GamePaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    void Resume(){
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }
    void Pause(){
        PauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        GamePaused = true;
    }
}
