using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DistanceToWall : MonoBehaviour
{


    public GameObject player;
    public  float Distance;

    void Update()
    {
        Distance = Vector3.Distance(transform.position, player.transform.position);
    }
}
