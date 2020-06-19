using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreParticleController : MonoBehaviour
{
    public Color pos;
    public Color neg;
    public Color neu;
    public float particleRadiusVertical = 1;
    public float particleRadiusHorizontal = 1;
    public Vector2 offset;

    private TextMeshProUGUI text;

    public float timeSolid;
    public float timeFading;

    private float setFading;

    bool worked = false;

    // Start is called before the first frame update
    void Start()
    {
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
            text.color = neu;
        else if (text.text.IndexOf('-') == 0)
            text.color = neg;
        else
            text.color = pos;

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
