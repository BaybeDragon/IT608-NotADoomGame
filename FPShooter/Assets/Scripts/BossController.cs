using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject main;
    public GameObject rayOrigin;
    public GameObject player;
    public float range = 10;
    public int currentHealth = 10;
    Animator anim;
    public float fireRateMin = 0.25f;
    public float fireRateMax = 1.5f;
    private float nextFire = 0f;
    PlayerStuff playerScript;


    void Start()
    {
        anim = GetComponent<Animator>();
        playerScript = player.GetComponent<PlayerStuff>();
        anim.SetBool("isShooting", true);
    }

    void Update()
    {
        transform.forward = player.transform.forward;
        if (Time.time > nextFire)
        {
            nextFire = Time.time + Random.Range(fireRateMin, fireRateMax);


            RaycastHit hit;
            rayOrigin.transform.LookAt(player.transform.position);
            Ray rayTest = new Ray(rayOrigin.transform.position, rayOrigin.transform.forward);

            if (Physics.Raycast(rayTest, out hit, 100f))
            {
                Debug.DrawRay(rayOrigin.transform.position, rayOrigin.transform.forward * 100, Color.blue);
                if (hit.collider.tag == "Player")
                {
                    float acc = Random.Range(0, 100);
                    if (acc < 80)
                    {
                        playerScript.TakeDamage(Random.Range(0, 15));
                    }
                }
            }
        }
    }

    public void Damage(int dmgAmount)
    {
        currentHealth -= dmgAmount;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
