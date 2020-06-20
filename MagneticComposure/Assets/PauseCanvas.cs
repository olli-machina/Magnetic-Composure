using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseCanvas : MonoBehaviour
{
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame(!canvas.enabled);
    }

    public void PauseGame(bool setting)
    {
        canvas.enabled = setting;

        if(setting)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        GameObject.FindObjectOfType<AudioMaster>().transform.Find("Button Click").GetComponent<AudioSource>().Play();
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
        GameObject.FindObjectOfType<AudioMaster>().transform.Find("Button Click").GetComponent<AudioSource>().Play();
    }
}
