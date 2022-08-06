using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DbLogin : MonoBehaviour
{
   public void GoToMenu() {
    SceneManager.LoadScene("LogInScene");
   }

   public void GoToRegister() {
    SceneManager.LoadScene("RegisterScene");
   }

   public void BackToLogin() {
      SceneManager.LoadScene("LogInScene");
   }

   public void BackToPlayScene() {
      SceneManager.LoadScene("PlayScene");
   }

   public void GoToScoreBoardScene() {
      SceneManager.LoadScene("ScoreScene");
   }
}
