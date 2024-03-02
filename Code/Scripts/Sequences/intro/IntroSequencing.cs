using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSequencing : MonoBehaviour
{


    public GameObject textBox;
    public GameObject dateDisplay;
    public GameObject placeDisplay;
    public AudioSource line01;
    public AudioSource line02;
    public GameObject allBlack;
    public GameObject loadText;



    void Start()
    {
        StartCoroutine(SequenceBegin());
    }

    IEnumerator SequenceBegin()
    {
        yield return new WaitForSeconds(3);
        placeDisplay.SetActive(true);
        yield return new WaitForSeconds(1);
        dateDisplay.SetActive(true);
        yield return new WaitForSeconds(1);
        placeDisplay.SetActive(false);
        dateDisplay.SetActive(false);
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Ночь на 30 июля 2002 года изменила меня навсегда...";
        line01.Play();
        yield return new WaitForSeconds(4);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(15);
        line02.Play();
        allBlack.SetActive(true);
        yield return new WaitForSeconds(1);
        loadText.SetActive(true);
        SceneManager.LoadScene(2);
    }
}
