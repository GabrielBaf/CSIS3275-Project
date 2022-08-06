using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogManager : MonoBehaviour
{   
   
    
    public GameObject treelvl2_1,treelvl2_2;
    private int questionTotal,questionsRight;
   private SpriteRenderer spriteRenderer;
   private PlayerMovement playerMovement;
    private Queue<string> sentences;
    private List<string> buttonTextQuestions;
    public GameObject dialogueUI,questionUI,player;
    public TMP_Text textDialogueUI,nameDialogueUI;
    public TMP_Text textQuestionUI,nameQuestionUI;
    public TMP_Text[] buttonsQuestions;
    
 
    // Start is called before the first frame update
    void Start()
    {
        
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        playerMovement = player.GetComponent<PlayerMovement>();
        sentences = new Queue<string>();
        buttonTextQuestions = new List<string>();
    }

    public void StartQuestions(Questions question){
        questionUI.SetActive(true);
        nameQuestionUI.text = question.name;
        
        Time.timeScale = 0f;

       textQuestionUI.text = question.questions;

       foreach(string option in question.answers){
        buttonTextQuestions.Add(option);
       }
       for(int i=0;i<buttonTextQuestions.Count;i++){
        buttonsQuestions[i].text = buttonTextQuestions[i];
       }
       buttonTextQuestions.Clear();
    }
   public void StartDialogue(Dialogue dialogue){
    dialogueUI.SetActive(true);
    nameDialogueUI.text = dialogue.name;
    Time.timeScale = 0f;
    sentences.Clear();

    foreach (string sentence in dialogue.sentences){
        sentences.Enqueue(sentence);
    }
    

    DisplayNextSentence();
   }
   public void DisplayNextSentence(){
    if(sentences.Count == 0){
        EndDialogue();
        return;
    }
    
    string sentence = sentences.Dequeue();
    textDialogueUI.text = sentence;
   }

  public void EndDialogue(){
    dialogueUI.SetActive(false);
    Time.timeScale = 1f;
    
   }
   public void RightAnswer(){
    //BattleHandler.healerUnlocked = true;
    HighScoreSing.Instance.SaveDmgUp();
    Time.timeScale = 1f;
    questionTotal =+ 1;
    questionsRight =+1;
    textQuestionUI.text = "You got it right!!!!!";
    Invoke("ChangeScene", 2f);
    if(treelvl2_1.activeInHierarchy  == false){
        HighScoreSing.Instance.enemy2_1 = false;
    }else if(treelvl2_2.activeInHierarchy  == false){
        HighScoreSing.Instance.enemy2_2 = false;
    }else if(treelvl2_2.activeInHierarchy  == false && treelvl2_1.activeInHierarchy == false){
        HighScoreSing.Instance.enemy2_1 = false;
        HighScoreSing.Instance.enemy2_2 = false;
    }else{
        HighScoreSing.Instance.enemy2_1 = true;
        HighScoreSing.Instance.enemy2_2 = true;
    }
   }
  public void WrongAnswer(){
    
    questionTotal =+ 1;
    textQuestionUI.text = "You got it Wrong!!!!!";
    Invoke("ChangeScene", 2.5f);
   
   }
   public void ChangeScene(){
    questionUI.SetActive(false);
    SceneManager.LoadScene("GameScene_TurnBattleSystem");
   
   }
   
}
