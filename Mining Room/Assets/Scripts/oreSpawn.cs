using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oreSpawn : MonoBehaviour {

    public Rigidbody ore;
    public KeyCode theKey;
    public float coolDown;
    public float hitsNeeded;

    private float hitsTaken;
    private float coolDownTimer;
    private bool veinLightUp;
    

    void Start () {
        
	}
	
	
	void Update () {
        if (Input.GetKeyDown(theKey) && coolDownTimer == 0)
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
            veinLightUp = true;

        }

        if (Input.GetKeyDown(theKey) && hitsTaken >= hitsNeeded)
        {
            Instantiate(ore, transform.position, Quaternion.identity);
            veinLightUp = false;
            coolDownTimer = coolDown;
            hitsTaken = 0;
        }
	}

     
}
