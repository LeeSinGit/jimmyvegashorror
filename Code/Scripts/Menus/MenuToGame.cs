using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToGame : MonoBehaviour
{

    public GameObject fadeOut;
    public GameObject loadText;
    public AudioSource buttonClick;
    public GameObject loadButton;
    public int loadInt;


    void Start()
    {
        loadInt = PlayerPrefs.GetInt("Auto Save");
        if (loadInt > 0)
        {
            loadButton.SetActive(true);
        }
    }

    public void NewGameButton()
    {
        StartCoroutine(NewGameStart());
    }

    IEnumerator NewGameStart()
    {
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(3);
        loadText.SetActive(true);
        SceneManager.LoadScene(1);
    }


    public void LoadGameButton()
    {
        StartCoroutine(LoadGameStart());
    }

    IEnumerator LoadGameStart()
    {
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(3);
        loadText.SetActive(true);
        SceneManager.LoadScene(loadInt);
    }


    public void LoadSite()
    {
        Application.OpenURL("https://vk.com/lisinsyoma");
    }


}
