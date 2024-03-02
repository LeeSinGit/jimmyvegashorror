using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject ThePlayer;
    public GameObject TextBox;
    private bool hasTriggered = false;
    public AudioSource Line03;

    void OnTriggerEnter()
    {   
        if (!hasTriggered)
        {
            this.GetComponent<BoxCollider>().enabled = false;
            ThePlayer.GetComponent<FirstPersonController>().enabled = false;
            StartCoroutine(ScenePlayer ());
            hasTriggered = true;
        }
    }

    IEnumerator ScenePlayer ()
    {
        TextBox.GetComponent<Text>().text = "Что это на столе?";
        Line03.Play();
        yield return new WaitForSeconds (2.5f);
        TextBox.GetComponent<Text>().text = "";
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
    }

}
