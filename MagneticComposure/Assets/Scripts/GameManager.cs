using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int wordSizeDrag;
    public string word;
    public string[] positiveLibrary;
    public string[] negativeLibrary;

    // Start is called before the first frame update
    void Start()
    {
        spawnWord();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnWord()
    {
        //pick word from array

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
