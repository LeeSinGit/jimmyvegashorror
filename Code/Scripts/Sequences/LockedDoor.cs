using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedDoor : MonoBehaviour
{

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public AudioSource lockedDoor;
    public GameObject firstKeyDoor;
    public AudioSource CreakSound;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 2)
        {
            ExtraCross.SetActive (true);
            ActionText.GetComponent<Text>().text = "Открыть дверь";
            ActionDisplay.SetActive (true);
            ActionText.SetActive (true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive (false);
                ActionText.SetActive (false);
                ExtraCross.SetActive (false);
                StartCoroutine(DoorReset());
            }
        }
    }

    void OnMouseExit()
    {
        ExtraCross.SetActive (false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }


    IEnumerator DoorReset()
    {
        if (GlobalInventory.firstDoorKey == false)
        {
            lockedDoor.Play();
            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            firstKeyDoor.GetComponent<Animation>().Play("FirstKeyDoorOpen");
            CreakSound.Play();
            yield return new WaitForSeconds(2);
            firstKeyDoor.GetComponent<BoxCollider>().enabled = false;
        }
    }

}
