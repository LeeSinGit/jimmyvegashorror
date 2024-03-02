using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateStalker : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        StalkerAI.isStalking = true;
    }


}
