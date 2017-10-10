using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuff : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ammoGun"))
        {
            other.gameObject.SetActive(false);
            //GameObject.Find("Cube").getComponent("GunShoot.cs").Ammo--;
        }
    }
}
