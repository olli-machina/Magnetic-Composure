using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreenController : MonoBehaviour
{
    public TextMeshProUGUI bodyText;
    public Image bestSentenceMagnetImage;
    public TextMeshProUGUI bestSentenceText;
    public TextMeshProUGUI bestSentenceLabelText;

    // Start is called before the first frame update
    void Start()
    {
        int min = (int)(PlayerPrefs.GetFloat("time") / 60);
        float sec = PlayerPrefs.GetFloat("time") % 60;

        string secStr = "";
        if (sec < 10)
            secStr = "0";
        secStr = secStr + sec;

        bodyText.text = bodyText.text + "\n\nSetences Filled: " + PlayerPrefs.GetInt("sentenceCount") + "\nTime Played: " + min + ":" + secStr;
        bestSentenceText.text = PlayerPrefs.GetString("bestSentence");
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        bestSentenceLabelText.fontSize = bodyText.fontSize;
    }
}
