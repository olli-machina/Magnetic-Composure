using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public float plannedFontWidth = 1;
    public Canvas worldSpace;
    public TextMeshProUGUI textUI;

    private List<float> collisions;
    private BoxCollider2D collider;

    void Start()
    {
        collisions = new List<float>();
        collider = GetComponent<BoxCollider2D>();
        ChooseNewPresets();
    }

    void ChooseNewPresets()
    {
        //Determine the New Sentence Data to currently use
        int rnd = Random.Range(0, presets.Count);
        currentText = presets[rnd].text;
        currentMultiplier = presets[rnd].multiplier;

        //Set canvas to the correct worldspace
        Vector2 vec = worldSpace.GetComponent<RectTransform>().sizeDelta;
        vec.x = plannedFontWidth * currentText.Length;
        worldSpace.GetComponent<RectTransform>().sizeDelta = vec;
        //Set trigger to the correct width
        Vector2 bec = collider.size;
        bec.x = plannedFontWidth * currentText.Length;
        collider.size = bec;

        //Determine collision points
        string test = currentText;
        float leftSide = transform.position.x - collider.size.x / 2.0f;
        collisions.Clear();
        while (test.IndexOf("_____") > -1)
        {
            Debug.Log("" + (leftSide + ((test.IndexOf("_____") + 2.5f) * plannedFontWidth)));
            collisions.Add(leftSide + ((test.IndexOf("_____") + 2.5f) * plannedFontWidth));
            leftSide = leftSide + ((test.IndexOf("_____") + 5) * plannedFontWidth);
            test = test.Substring(test.IndexOf("_____") + 6);
        }

        textUI.text = currentText;
    }

    bool CheckForWordEntrance(float x, TextMeshProUGUI wd)
    {
        for(int i = 0; i < collisions.Count; i++)
        {
            if(Mathf.Abs(x - collisions[i]) < 0.2f)
            {

                if(wd.tag == "Positive")
                    ChangeScore(wd.text.Length);
                else if (wd.tag == "Negative")
                    ChangeScore(-wd.text.Length);

                collisions.RemoveAt(i);
                i--;

                if(collisions.Count == 0)
                {
                    //This can be updated to have a timer before it completely resets, perhaps having a fancy fade away then reappear
                    ChooseNewPresets();
                }

                return true;
            }
        }
        return false;
    }

    void ChangeScore(int points)
    {
        Debug.Log("points: " + (points * currentMultiplier));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "words" || collision.tag == "Positive" || collision.tag == "Negative")
        {
            bool fitsBlank = CheckForWordEntrance(collision.transform.position.x, collision.GetComponent<TextMeshProUGUI>());
            if(fitsBlank) //This can be updated to have a timer before it completely resets, perhaps having a fancy lock-in color.
                Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        
    }
}
