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

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScore> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;

    private void Awake() {
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = transform.Find("HighscoreEntreyTemplate");

        entryTemplate.gameObject.SetActive(false);
        float templateHeight = 20f;

        highScoreEntryList = new List<HighScore>() {
            new HighScore {score = www.score, name = www.name}
        };


        foreach (HighScore highScore in highScoreEntryList)
        {
            CreateHighScoreEntryTransform(highScore, entryContainer, highScoreEntryTransformList);
        }

    }

    private void CreateHighScoreEntryTransform(HighScore highScoreEntry, Transform container, List<Transform> transformList) {
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        IEnumerator GetScore() {
            WWWForm form = new WWWForm();
            form.ReadField("score", score.text);
            WWW www = new WWW("http://localhost/sqlconnect/GetScores.php", form);
            Debug.Log(www);
            yield return www;

            int rank = transformList.Count + 1;
            string rankString;

            switch(rank) {
            case 1: rankString = "1ST";break;
            case 2: rankString = "2ND";break;
            case 3: rankString = "3RD";break;
            default: rankString = rank + "TH"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;
        entryTransform.Find("scoreText").GetComponent<Text>().text = www.score.ToString();
        entryTransform.Find("nameText").GetComponent<Text>().text = www.name.ToString();

        transformList.Add(entryTransform);
        }
    }

    private class HighScore {
        public int score;
        public string name;
    }
}
