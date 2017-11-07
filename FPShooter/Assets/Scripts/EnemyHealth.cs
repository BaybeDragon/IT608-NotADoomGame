using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int currentHealth = 2;
    public GameObject door;
    OpenDoor doorscript; 

    void Start()
    {
        doorscript = door.GetComponent<OpenDoor>();
    }

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        { 
            gameObject.SetActive(false);
            doorscript.addKill();
        }
    }
}
