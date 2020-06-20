using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Color pos;
    public Color neg;
    public Color neu;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI senetenceCountText;
    public GameObject scoreParticlePrefab;
    public ParticleSystem ps;

    public int score;
    public int sentencesFilledCount;
    public float time;
    public int scoreToWin;


    public int sentencesFilled;
    public float distanceBetweenFilledSentences;
    public Transform filledSentenceStartingPoint;
    public GameObject filledSentencePrefab;

    public float bestScore = 0;
    public string bestSentence = "";

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        scoreText.text = "" + score + "/" + scoreToWin;
        senetenceCountText.text = "" + sentencesFilledCount + "\nSentences\nFilled";
    }

    public void ChangeScore(int points, string sentenceFilled)
    {

        GameObject.FindObjectOfType<AudioMaster>().transform.Find("Finish Sentence").GetComponent<AudioSource>().Play();

        if (points > 0)
            ps.startColor = pos;
        else if (points < 0)
            ps.startColor = neg;
        else
            ps.startColor = neu;

        ps.Play();

        sentencesFilledCount++;
        score += points;
        GameObject particle = Instantiate(scoreParticlePrefab, scoreText.transform);
        particle.GetComponent<TextMeshProUGUI>().text = "" + points;

        if(bestScore < points)
        {
            bestScore = points;
            bestSentence = sentenceFilled;
        }

        if (score >= scoreToWin)
        {
            PlayerPrefs.SetFloat("time", time);
            PlayerPrefs.SetInt("sentenceCount", sentencesFilledCount);
            PlayerPrefs.SetString("bestSentence", bestSentence);

            Debug.Log("WINNER! " + time + " Seconds");
            Debug.Log("Best Sentence: " + bestSentence);

            SceneManager.LoadScene(2);
        }
    }
}
