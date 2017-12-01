using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oreSpawn : MonoBehaviour {

    public Rigidbody ore;
    public KeyCode theKey;
    public float coolDown;
    public float hitsNeeded;
    public Renderer rend;

    private float hitsTaken;
    private float coolDownTimer;
    private bool veinLightUp;
    

    void Start () {
        rend.enabled = true;
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
            rend.enabled = true;
            veinLightUp = true;

        }

        if (Input.GetKeyDown(theKey) && hitsTaken >= hitsNeeded)
        {
            Instantiate(ore, transform.position, Quaternion.identity);
            rend.enabled = false;
            veinLightUp = false;
            coolDownTimer = coolDown;
            hitsTaken = 0;
        }


	}

     
}
