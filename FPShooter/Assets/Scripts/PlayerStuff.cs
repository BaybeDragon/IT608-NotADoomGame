using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStuff : MonoBehaviour
{
    public string stage;
    int playerHealth = 100;
    public GameObject knife, pistol, hands, ammoText, playerText;
    GunShoot pis;
    Text ammoAmount,playerHealthText;
    // Use this for initialization
    void Start()
    {
        ammoAmount = ammoText.GetComponent<Text>();
        playerHealthText = playerText.GetComponent<Text>();
        pis = pistol.GetComponent<GunShoot>();
        /*
        shot = shotgun.GetComponent<GunShoot>();
        rif = rifle.GetComponent<GunShoot>();
        sub = subway.GetComponent<GunShoot>();
        */
        playerHealthText.text = "100";
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
        playerHealthText.text = playerHealth.ToString();
        checkWeapons();
    }

    private void checkWeapons()
    {
        
        if (Input.GetKey(KeyCode.Alpha1))
        {
            disableWeapons();
            hands.SetActive(true);
            ammoAmount.text = "";
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            disableWeapons();
            knife.SetActive(true);
            ammoAmount.text = "";
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            disableWeapons();
            pistol.SetActive(true);
            ammoAmount.text = pis.ammo.ToString();
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

    public void TakeDamage(int dmgAmmount)
    {
        playerHealth -= dmgAmmount;
        if(playerHealth <= 0)
        {
            SceneManager.LoadSceneAsync(stage);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ammoPistol"))
        {
            other.gameObject.SetActive(false);
            pis.ammo += 10;
            if (pistol.activeInHierarchy)
            {
                ammoAmount.text = pis.ammo.ToString();
            }
        }
        /*
        else if (other.gameObject.CompareTag("ammoShotgun"))
        {
            other.gameObject.SetActive(false);
            shot.ammo += 10;
            if (shotgun.activeInHierarchy)
            {
                ammoAmount.text = shot.ammo.ToString();
            }
        }
        else if (other.gameObject.CompareTag("ammoRifle"))
        {
            other.gameObject.SetActive(false);
            rif.ammo += 10;
            if (rifle.activeInHierarchy)
            {
                ammoAmount.text = rif.ammo.ToString();
            }
        }
        else if (other.gameObject.CompareTag("ammoSubway"))
        {
            other.gameObject.SetActive(false);
            sub.ammo += 10;
            if (subway.activeInHierarchy)
            {
                ammoAmount.text = sub.ammo.ToString();
            }
        }
        */
    }
}
