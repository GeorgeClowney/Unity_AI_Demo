using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that tracks the player health
public class PlayerCharacter : MonoBehaviour
{
    private int _health;
    // Start is called before the first frame update
    void Start()
    {
        _health = 5;
    }
       //When the Hurt function is called the player takes (damage)
       public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log("Health: " + _health);
    }   
}
