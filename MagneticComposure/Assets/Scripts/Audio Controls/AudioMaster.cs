using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioMaster : MonoBehaviour
{
    public GameObject menu;
    public GameObject game;

    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = 1;

        if(GameObject.FindObjectsOfType<AudioMaster>().Length !=1 )
        {
            Destroy(this.gameObject);
        }
        Object.DontDestroyOnLoad(this.gameObject);
    }

    public void buttonNoise()
    {
        transform.Find("Button Pressed").GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex > 0)
        {
            if(menu.activeSelf)
            {
                menu.SetActive(false);
                game.SetActive(true);
                game.GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            if (game.activeSelf)
            {
                menu.SetActive(true);
                game.SetActive(false);
                menu.GetComponent<AudioSource>().Play();
            }
        }
    }
}
