using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CallExitDoor : MonoBehaviour
{

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    // public GameObject TheDoor;
    // public AudioSource CreakSound;
    public GameObject ExtraCross;
    public GameObject FadeOut;
    public GameObject Loading;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 1)
        {
            ActionText.GetComponent<Text>().text = "Открыть дверь";
            ExtraCross.SetActive (true);
            ActionDisplay.SetActive (true);
            ActionText.SetActive (true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 1)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                StartCoroutine(FadeToExit());
                // TheDoor.GetComponent<Animation>().Play("DoorOpen");
                // CreakSound.Play();
            }
        }
    }

    void OnMouseExit()
    {
        ExtraCross.SetActive (false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator FadeToExit()
    {
        FadeOut.SetActive(true);
        Loading.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(5);
    }
}
