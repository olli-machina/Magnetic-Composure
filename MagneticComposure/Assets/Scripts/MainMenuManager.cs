using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject[] slides;

    // Start is called before the first frame update
    void Start()
    {
        BackToMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonSound()
    {
        GameObject.FindObjectOfType<AudioMaster>().transform.Find("Button Click").GetComponent<AudioSource>().Play();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowSlide(GameObject obj)
    {
        BackToMenu();
        obj.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        foreach (GameObject obj in slides)
            obj.SetActive(false);
    }
}
