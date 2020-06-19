using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreParticleController : MonoBehaviour
{
    public float particleRadiusVertical = 1;
    public float particleRadiusHorizontal = 1;
    public Vector2 offset;

    private TextMeshProUGUI text;
    private ScoreManager scoreManager;

    public float timeSolid;
    public float timeFading;

    private float setFading;

    bool worked = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        text = GetComponent<TextMeshProUGUI>();
        setFading = timeFading;
    }

    // Update is called once per frame
    void Update()
    {
        if(!worked)
        {
            Vector2 pos = transform.position;
            pos = pos + offset + new Vector2(Random.Range(-particleRadiusHorizontal, particleRadiusHorizontal), Random.Range(-particleRadiusVertical, particleRadiusVertical));
            transform.position = pos;
            worked = true;
        }

        //Set Correct Color
        if (text.text == "0")
            text.color = scoreManager.neu;
        else if (text.text.IndexOf('-') == 0)
            text.color = scoreManager.neg;
        else
            text.color = scoreManager.pos;

        if(timeSolid > 0)
        {
            timeSolid = timeSolid - Time.deltaTime;
        }
        else if(timeFading > 0)
        {
            timeFading = timeFading - Time.deltaTime;
            Color txtColor = text.color;
            txtColor.a = timeFading/setFading;
            text.color = txtColor;
            if(timeFading <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
