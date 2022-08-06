using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DbLogin : MonoBehaviour
{
   public void GoToMenu() {
    SceneManager.LoadScene("SampleScene 1");
   }

   public void GoToRegister() {
    SceneManager.LoadScene("RegisterScene");
   }

   public void BackToLogin() {
      SceneManager.LoadScene("LogInScene");
   }
}
