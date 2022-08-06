using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DbConection : MonoBehaviour
{
    public TMP_Text nameField;
    public TMP_Text passwordField;
    public Button submitButton;

    public void CallRegister() {
        StartCoroutine(Register());
        SceneManager.LoadScene("LogInScene");
    }

    public void CallLogin() {
        StartCoroutine(LoginPlayer());
        SceneManager.LoadScene("SampleScene 1");
        // if(DbManager.loggedIn) {
        // }
    }

    IEnumerator Register() {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        if(www.text == "0") {
            Debug.Log("User created Successfully");
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene 1");
        } else {
            Debug.Log("User creation failed. Error  #" + www.text);
        }
    }

    IEnumerator LoginPlayer() {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        Debug.Log(nameField.text);
        Debug.Log(passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;
        
        // if(www.text[0] == '0') {
        //     DbManager.username = nameField.text;
        //     DbManager.score = int.Parse(www.text.Split('\t')[1]);
        // } else {
        //     Debug.Log("User login Failed. Error #" + www.text);
        // }

        // VerifyInputs();
    }

    public void VerifyInputs() {
        submitButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >= 4);
    }
}
