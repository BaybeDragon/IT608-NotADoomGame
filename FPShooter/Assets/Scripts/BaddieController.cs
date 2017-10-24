using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaddieController : MonoBehaviour {

    public GameObject player;
    bool triggered;
    Animator anim;
    public float fireRateMin = 0.25f;
    public float fireRateMax = 1.5f;
    private float nextFire = 0f;

    // Use this for initialization
    void Start () {
        triggered = false;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {
        transform.forward = player.transform.forward;
        if (triggered)
        {
            anim.SetBool("BaddieTriggered", true);
            
            if(Time.time > nextFire)
            {
                anim.SetTrigger("BaddieShoot");
                nextFire = Time.time + Random.Range(fireRateMin, fireRateMax);
            }
        }
	}

    public void Triggered()
    {
        triggered = true;
        nextFire = Time.time + Random.Range(fireRateMin, fireRateMax);

    }



}
