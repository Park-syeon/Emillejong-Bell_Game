using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public string SceneToLoad;
    public GameObject canvas;
    public GameObject canvas2;
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
    public void PreGame()
    {
        canvas.SetActive(false);
        canvas2.SetActive(true);
        Title2 title2 = FindObjectOfType<Title2>();
        title2.startStory();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void Start()
    {
        canvas.SetActive(true);
        canvas2.SetActive(false);
    }
}
