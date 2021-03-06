﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaddieController : MonoBehaviour {
    public GameObject main;
    public GameObject rayOrigin;
    public GameObject player;
    public float range = 10;

    bool triggered;
    Animator anim;
    public float fireRateMin = 0.25f;
    public float fireRateMax = 1.5f;
    private float nextFire = 0f;
    PlayerStuff playerScript;
    NavMeshAgent agent;
    

    // Use this for initialization
    void Start () {
        agent = main.GetComponent<NavMeshAgent>();
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
            //Debug.Log(Vector3.Distance(transform.position, player.transform.position));
            if(Vector3.Distance(transform.position,player.transform.position) <= range)
            {
                anim.SetBool("BaddieWalking", false);
                agent.destination = transform.position;
                if (Time.time > nextFire)
                {
                    float acc = Random.Range(0, 100);
                    nextFire = Time.time + Random.Range(fireRateMin, fireRateMax);
                    anim.SetTrigger("BaddieShoot");




                    //raycast goes here
                    RaycastHit hit;
                    rayOrigin.transform.LookAt(player.transform.position);
                    Ray rayTest = new Ray(rayOrigin.transform.position, rayOrigin.transform.forward);
                    if (Physics.Raycast(rayTest, out hit, 100f))
                    {
                        Debug.DrawRay(rayOrigin.transform.position, rayOrigin.transform.forward * 100, Color.blue);
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
            else
            {
                agent.destination = player.transform.position;
                anim.SetBool("BaddieWalking", true);
            }

        }
	}

    public void Triggered()
    {
        triggered = true;
        nextFire = Time.time + Random.Range(fireRateMin, fireRateMax);

    }



}
