using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oreSpawn : MonoBehaviour {

    public Rigidbody ore;
	
    public KeyCode theKey = KeyCode.None;

    public float coolDown = 5f;
    private float coolDownTimer;

    public float hitsNeeded;

    private float hitsTaken;

	void Start () {
		
	}
	
	
	void Update () {
        if (Input.GetKeyDown(theKey))
        {
            hitsTaken++;
        }

        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        if (Input.GetKeyDown(theKey) && hitsTaken >= hitsNeeded && coolDownTimer == 0)
        {
            Instantiate(ore, transform.position, Quaternion.identity);
            coolDownTimer = coolDown;
            hitsTaken = 0;
        }
	}

     
}
