using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

[System.Serializable]
public class SentencePresets
{
    public string text;
    public int multiplier;
}

public class SentenceController : MonoBehaviour
{

    public List<SentencePresets> presets;
    public string currentText;
    public int currentMultiplier;
    public int currentPoints;
    public float plannedFontWidth = 1;
    public Canvas worldSpace;
    public TextMeshProUGUI textUI;

    public float inSlotRange = .5f;

    private List<float> collisions;
    private BoxCollider2D myBoxCollider;
    private ScoreManager scoreManager;
    public List<GameObject> wordsCaught;

    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        collisions = new List<float>();
        wordsCaught = new List<GameObject>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        ChooseNewPresets();
    }

    void ChooseNewPresets()
    {
        currentPoints = 0;

        //Determine the New Sentence Data to currently use
        int rnd = Random.Range(0, presets.Count);
        currentText = presets[rnd].text;
        currentMultiplier = presets[rnd].multiplier;

        //Set canvas to the correct worldspace
        Vector2 vec = worldSpace.GetComponent<RectTransform>().sizeDelta;
        vec.x = plannedFontWidth * currentText.Length;
        worldSpace.GetComponent<RectTransform>().sizeDelta = vec;
        //Set trigger to the correct width
        Vector2 bec = myBoxCollider.size;
        bec.x = plannedFontWidth * currentText.Length;
        myBoxCollider.size = bec;

        //Determine collision points
        string test = currentText;
        float leftSide = transform.position.x - myBoxCollider.size.x / 2.0f;
        collisions.Clear();
        while (test.IndexOf("_____") > -1)
        {
            collisions.Add(leftSide + ((test.IndexOf("_____") + 2.5f) * plannedFontWidth));
            leftSide = leftSide + ((test.IndexOf("_____") + 5) * plannedFontWidth);
            if (test.Length > test.IndexOf("_____") + 6)
                test = test.Substring(test.IndexOf("_____") + 6);
            else
                test = "";
        }

        textUI.text = currentText;
    }

    bool CheckForWordEntrance(float x, TextMeshProUGUI wd)
    {
        for(int i = 0; i < collisions.Count; i++)
        {
            if(Mathf.Abs(x - collisions[i]) < inSlotRange)
            {
                //Determin changing points value
                int changePointsBy = 0;
                if(wd.tag == "Positive")
                    changePointsBy =  wd.text.Length * currentMultiplier;
                else if (wd.tag == "Negative")
                    changePointsBy = - wd.text.Length * currentMultiplier;

                //Coloring text
                if (changePointsBy > 0)
                    wd.color = scoreManager.pos;
                else if (changePointsBy < 0)
                    wd.color = scoreManager.neg;
                else
                    wd.color = scoreManager.neu;

                //Make the word still
                Destroy(wd.GetComponent<FallingWords>());
                Destroy(wd.GetComponent<Rigidbody2D>());
                Destroy(wd.GetComponent<BoxCollider2D>());
                wordsCaught.Add(wd.gameObject);

                //Update points
                currentPoints = currentPoints + changePointsBy;

                //Removes this blank slot
                collisions.RemoveAt(i);
                i--;

                if(collisions.Count == 0)
                {
                    string sentenceCreated = currentText;
                    wordsCaught = wordsCaught.OrderBy(a => a.transform.position.x).ToList();
                    
                    foreach(GameObject obj in wordsCaught)
                    {
                        if (sentenceCreated.Length > sentenceCreated.IndexOf('_') + 5)
                            sentenceCreated = sentenceCreated.Substring(0, sentenceCreated.IndexOf('_')) + obj.GetComponent<TextMeshProUGUI>().text + sentenceCreated.Substring(sentenceCreated.IndexOf('_') + 5);
                        else
                            sentenceCreated = sentenceCreated.Substring(0, sentenceCreated.IndexOf('_')) + obj.GetComponent<TextMeshProUGUI>().text;
                    }

                    scoreManager.ChangeScore(currentPoints, sentenceCreated);

                    //This can be updated to have a timer before it completely resets, perhaps having a fancy fade away then reappear
                    while (wordsCaught.Count != 0)
                    {
                        Destroy(wordsCaught[0]);
                        wordsCaught.RemoveAt(0);
                    }
                    ChooseNewPresets();
                }

                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "words" || collision.tag == "Positive" || collision.tag == "Negative")
        {
            bool fitsBlank = CheckForWordEntrance(collision.transform.position.x, collision.GetComponent<TextMeshProUGUI>());
        }
    }

    void Update()
    {
        
    }
}
