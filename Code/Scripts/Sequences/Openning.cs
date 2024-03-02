using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;


public class Openning : MonoBehaviour
{

    public GameObject ThePlayer;
    public GameObject FadeScreenIn;
    public GameObject TextBox;
    public AudioSource Line01;
    public AudioSource Line02;

    void Start()
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer ());
    }

    IEnumerator ScenePlayer ()
    {
        yield return new WaitForSeconds (1.5f);
        FadeScreenIn.SetActive (false);
        TextBox.GetComponent<Text>().text = "Как я оказался здесь?";
        Line01.Play();
        yield return new WaitForSeconds (1.5f);
        TextBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds (0.5f);
        TextBox.GetComponent<Text>().text = "Мне нужно бежать отсюда!";
        Line02.Play();
        yield return new WaitForSeconds (2);
        TextBox.GetComponent<Text>().text = "";
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;


    }

}
