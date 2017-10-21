using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour {
    public GameObject baddie;
    BaddieController cont;
	// Use this for initialization
	void Start () {
        cont = baddie.GetComponent<BaddieController>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag("Player"))
        {
            cont.Triggered();
        }
	}
}
