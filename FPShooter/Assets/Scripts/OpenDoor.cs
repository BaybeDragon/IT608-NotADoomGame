using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    int killCount = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (killCount >= 12)
        {
            gameObject.SetActive(false);
        }
	}

    public void addKill()
    {
        killCount += 1;
    }
}
