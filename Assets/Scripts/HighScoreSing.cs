using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreSing : MonoBehaviour
{   
    private static HighScoreSing _Instance;
    private CharacterBattle characterBattle;
    public bool isLevel2,isLevel3;
    public bool enemy2_1 = true;
    public bool enemy2_2 = true;
    public int playtime = 0;
    private float seconds = 0;
    private int minutes = 0;
    private int hours = 0;
    private int days = 0;
    int damageAmount = 40;
    public static HighScoreSing Instance{
        get
        {
            if (!_Instance)
            {
                _Instance = new GameObject().AddComponent<HighScoreSing>();
               
                _Instance.name = _Instance.GetType().ToString();
                
                DontDestroyOnLoad(_Instance.gameObject);
            }
            return _Instance;
        }
    }
   
    public void Update(){
        seconds = seconds + Time.deltaTime;
    }
    public void SaveDmgUp(){
        int extraDmg = 5;
       damageAmount = damageAmount + extraDmg;
    }
    public int GetDmg(){
        return damageAmount;
    }
    public void changeLevel(){
       if(isLevel2){
        if(enemy2_1 == false){
            SceneManager.LoadScene("Scene2_1");
        }else if(enemy2_2 == false){
            SceneManager.LoadScene("Scene2_2");
        }else if(enemy2_2 == false && enemy2_1 == false){
             SceneManager.LoadScene("Scene3");
             isLevel2 = false;
             isLevel3 = true;
        }
       }else if(isLevel3){

       }else{
        SceneManager.LoadScene("Scene2");
       }
    }
}
