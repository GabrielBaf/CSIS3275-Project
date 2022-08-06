using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreSing : MonoBehaviour
{   
    private static HighScoreSing _Instance;
    private CharacterBattle characterBattle;
    public bool isLevel2 = false,isLevel3 = false;
    public bool enemy2_1 = true;
    public bool enemy2_2 = true;
    private int questionTotal = 0,questionsRight = 0;
    public int playtime = 0;
    private float seconds = 0;
    private int minutes = 0;
    private int hours = 0;
    private int days = 0;
    public int damageAmount = 40;
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
    public void Level2_1(){
        enemy2_1 = false;
    }
     public void Level2_2(){
        enemy2_2 = false;
    }
    public void EndLevel2(){
        enemy2_1 = true;
        enemy2_2 = true;
    }
     public void QuestionRight(){
        questionTotal ++;
        questionsRight ++;
    }
      public void QuestionWrong(){
        questionTotal ++;
    }
    public void ChangeLevel(){
       if(isLevel2){
        if(enemy2_1 == false){
            SceneManager.LoadScene("Scene2_1");
        }else if(enemy2_2 == false){
            SceneManager.LoadScene("Scene2_2");
        }else if(enemy2_2 == false && enemy2_1 == false){
             SceneManager.LoadScene("Scene3");
             isLevel2 = false;
             isLevel3 = true;
             EndLevel2();
        }
       }else if(isLevel3){

       }else{
        SceneManager.LoadScene("Scene2");
        isLevel2 = true;
       }
    }
}
