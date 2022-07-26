using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogManager : MonoBehaviour
{

    private Queue<string> sentences;
    private List<string> buttonTextQuestions;
    public GameObject dialogueUI,questionUI;
    public TMP_Text textDialogueUI,nameDialogueUI;
    public TMP_Text textQuestionUI,nameQuestionUI;
    public TMP_Text[] buttonsQuestions;
    
 
    // Start is called before the first frame update
    void Start()
    {
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

   void EndDialogue(){
    dialogueUI.SetActive(false);
    Time.timeScale = 1f;
    Debug.Log("End");
   }
   public void RightAnswer(){
    Time.timeScale = 1f;
    questionUI.SetActive(false);
    textQuestionUI.text = "You got it right!!!!!";
   }
  public void WrongAnswer(){
    Time.timeScale = 1f;
    questionUI.SetActive(false);
    textQuestionUI.text = "You got it Wrong!!!!!";
   }
}
