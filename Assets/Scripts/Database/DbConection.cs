using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;

public class DbConection
{
    // private string secretKey = "5GG";
    // public string addScoreUrl = "http://localhost/game/addScores.php";
    // public string highScore = "http://localhost/game/display.php";
    // public Text name;
    // public Text socre;
    // public Text nameResult;
    // public Text scoreResult;

    // public void GetScore() {
    //     nameResult.text = "Player: \n \n";
    //     scoreResult.text = "Score: \n \n";
    //     StartRoutine();
    // }

    // public void SendScore() {
    //     StartRoutine(PostScore(name.text, Convert.ToInt32(score.text)));
    //     name.gameObject.transform.parent.GetComponent<InputField>().text;
    //     score.gameObject.transform.parent.GetComponent<InputField>().text;
    // }

    // IEnumerator GetScores() {
    //     UnityWebRequest hs_get = UnityWebRequest.Get(highScore);
    //     yield return hs_get.SendWebRequest();

    //     if(hs_get.error != null) {
    //         Debug.Log("There was an error getting the high score: " + hs_get.error);
    //     } else {
    //         string dataText = hs_get.downloadHandler.text;
    //         MatchCollection mc = Regex.Matches(dataText, @"_");

    //         if(mc.Count > 0) {
    //             string[] spliData = Regex.Split(dataText, @"_");
    //             for(int i = 0; i < mc.Count; i++) {
    //                 if(i % 2 == 0) {
    //                     nameResult.text += spliData[i];
    //                 } else {
    //                     scoreResult.text += spliData[i];
    //                 }
    //             }
    //         }
    //     }
    // }

    // IEnumerator PostScore(string name, int score) {
    //     string hash = HashInput(name + score + secretKey);
    //     string post_url = addScoreUrl + "name=" + UnityWebRequest.EscapeURL(name) + "&score=" + score + "&hash=" + hash;
    //     UnityWebRequest hs_post = UnityWebRequest.Post(post_url, hash);
    //     yield return hs_post.SendWebRequest();

    //     if(hs_post != null) {
    //         Debug.Log("There was an error posting the high score: "  + hs_post);
    //     }
    // }

    // public string HashInput(string input) {
    //     SHA256Managed hm = new SHA256Managed();
    //     byte[] hashValue = hm.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input));
    //     string hash_convert = BitConverter.ToString(hashValue).Replace("-", "").ToLower();

    //     return hash_convert;
    // }
}
