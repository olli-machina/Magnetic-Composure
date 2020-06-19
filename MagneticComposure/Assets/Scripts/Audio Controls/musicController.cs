using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicController : MonoBehaviour
{
    public string pref = "mus";
    static public float gameControl = 1;
    private float standardVolume;

    // Start is called before the first frame update
    void Start()
    {
        standardVolume = GetComponent<AudioSource>().volume;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().volume = standardVolume * gameControl * PlayerPrefs.GetFloat(pref);
    }
}
