using UnityEngine;

public class ZombieDeath : MonoBehaviour
{

    public int EnemyHealth = 20;
    public GameObject TheEnemy;
    // public int StatusCheck;


    void DamageObject (int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
        
    }

}
