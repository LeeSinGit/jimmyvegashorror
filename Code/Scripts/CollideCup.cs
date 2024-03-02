using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideCup : MonoBehaviour
{


    public AudioSource impactFX;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1)
        {
            impactFX.Play();
        }
    }

}
