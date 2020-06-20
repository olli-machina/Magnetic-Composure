using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPlayerPref : MonoBehaviour
{
    public string perf;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Slider>().value = PlayerPrefs.GetFloat(perf);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat(perf, GetComponent<Slider>().value);
    }

    public void Sound()
    {
        GameObject.FindObjectOfType<AudioMaster>().transform.Find("Button Click").GetComponent<AudioSource>().Play();
    }
}
