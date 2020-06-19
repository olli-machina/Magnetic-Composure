using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class FallingWords : MonoBehaviour
{
    public int drag, wordVibe;
    public bool good;
    public string wordMain;
    public TMP_Text wordText;
    GameManager gameManager;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        wordText = GetComponent<TMP_Text>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();

        wordVibe = Random.Range(0, 2); //positive or negative word
        if (wordVibe == 1)
        {
            good = true;
            transform.gameObject.tag = "Positive";
        }
        else
        {
            good = false;
            transform.gameObject.tag = "Negative";
        }

        wordMain = gameManager.RandomWord(good); //get the word
        Debug.Log(wordMain);
        wordText.text = wordMain; //set the word

        drag = wordMain.Length * 2;
        rb.drag = drag; //make the movement speed change
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Positive" || col.tag != "Negative")
        {
            Physics2D.IgnoreCollision(col.GetComponent<Collider2D>(), transform.GetComponent<Collider2D>());
            
        }
        else if (col.tag == gameObject.tag)
        {
            //add to score
        }
        else
        {
            //subtract score
        }

    }
}
