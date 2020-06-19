using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int wordSizeDrag;
    public string word;
    public string[] positiveLibrary;
    public string[] negativeLibrary;
    public float spawnTimer = 3.0f, randomX;
    public GameObject newWord, wordParent;
    private GameObject instWord;
    Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnWord();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0.0f)
        {
            spawnWord();
            spawnTimer = 3.0f;
        }
    }

    public void spawnWord()
    {
        randomX = Random.Range(-342f, -329f);
        spawnPoint = new Vector3(randomX, -184f, 0f);
        //spawnPoint = instWord.transform.TransformPoint(spawnPoint);
            //transform.TransformPoint(spawnPoint)
        instWord = Instantiate(newWord, wordParent.transform.TransformPoint(spawnPoint), Quaternion.identity, wordParent.transform);
        //instWord.transform.TransformPoint(spawnPoint);
    }

    public string RandomWord(bool good)
    {
        if (good)
        {
            int randomWord = Random.Range(0, positiveLibrary.Length);
            return positiveLibrary[randomWord];
        }
        else
        {
            int randomWord = Random.Range(0, negativeLibrary.Length);
            return negativeLibrary[randomWord];
        }
    }
}
