using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuff : MonoBehaviour
{

    public GameObject knife, pistol, hands, shotgun, rifle, subway;

    // Use this for initialization
    void Start()
    {

    }

    void disableWeapons()
    {
        knife.SetActive(false);
        pistol.SetActive(false);
        hands.SetActive(false);
        /*
        shotgun.SetActive(false);
        rifle.SetActive(false);
        subway.SetActive(false);
        */
    }

    // Update is called once per frame
    void Update()
    {
        checkWeapons();
    }

    private void checkWeapons()
    {
        
        if (Input.GetKey(KeyCode.Alpha1))
        {
            disableWeapons();
            hands.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            disableWeapons();
            knife.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            disableWeapons();
            pistol.SetActive(true);
        }
        /*
        if (Input.GetKey(KeyCode.Alpha4))
        {
            disableWeapons();
            shotgun.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            disableWeapons();
            rifle.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            disableWeapons();
            subway.SetActive(true);
        }
        */
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
