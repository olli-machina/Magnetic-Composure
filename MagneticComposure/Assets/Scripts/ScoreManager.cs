using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public GameObject scoreParticlePrefab;

    public int score;
    public int sentencesFilledCount;
    public float time;
    public int scoreToWin;


    public int sentencesFilled;
    public float distanceBetweenFilledSentences;
    public Transform filledSentenceStartingPoint;
    public GameObject filledSentencePrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        scoreText.text = "" + score + "/200";
    }

    public void ChangeScore(int points)//, string sentenceFilled)
    {
        sentencesFilledCount++;
        score += points;
        GameObject particle = Instantiate(scoreParticlePrefab, scoreText.transform);
        particle.GetComponent<TextMeshProUGUI>().text = "" + points;

        if (score >= scoreToWin)
            Debug.Log("WINNER! " + time + " Seconds");
    }
}
