using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieController : MonoBehaviour {

    public GameObject rayOrigin;
    public GameObject player;
    bool triggered;
    Animator anim;
    public float fireRateMin = 0.25f;
    public float fireRateMax = 1.5f;
    private float nextFire = 0f;
    PlayerStuff playerScript;

    // Use this for initialization
    void Start () {
        triggered = false;
        anim = GetComponent<Animator>();
        playerScript = player.GetComponent<PlayerStuff>();
    }

    // Update is called once per frame
    void Update () {
        
        transform.forward = player.transform.forward;
        if (triggered)
        {
            anim.SetBool("BaddieTriggered", true);
            
            if(Time.time > nextFire)
            {
                float acc = Random.Range(0, 100);
                nextFire = Time.time + Random.Range(fireRateMin, fireRateMax);
                anim.SetTrigger("BaddieShoot");


                //raycast goes hereVector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
                RaycastHit hit;
                
                if (Physics.Raycast(rayOrigin.transform.position, rayOrigin.transform.forward, out hit, 100))
                {
                    //Debug.Log("Seen");
                    if (hit.collider.tag == "Player")
                    {
                        if (acc < 80)
                        {
                            playerScript.TakeDamage(10);
                        }
                    }
                }
            }
        }
	}

    public void Triggered()
    {
        triggered = true;
        nextFire = Time.time + Random.Range(fireRateMin, fireRateMax);

    }



}
