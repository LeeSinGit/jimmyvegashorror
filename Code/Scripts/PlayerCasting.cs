using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCasting : MonoBehaviour
{

    public static float DistanceFromTarget;
    public float ToTarget;


    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            ToTarget = Hit.distance;
            DistanceFromTarget = ToTarget;
        }
    }
}
