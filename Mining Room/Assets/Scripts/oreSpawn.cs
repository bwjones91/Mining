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
    private bool shaking = false;

    //private ObjectShake objectShaking;
    Vector3 originalPos;
    
    private float shakeAmt = 100f;
    

    void Start () {
        rend.enabled = true;
        originalPos = transform.position;
    }
	
	
	void Update () {
        if (Input.GetKeyDown(theKey) && coolDownTimer == 0)
        {
            hitsTaken++;
            ShakeMe();
            //objectShaking.ShakeOre(1.5f, 0.5f);
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
            Invoke("CreateOre", 0.5f);
            veinLightUp = false;
            coolDownTimer = coolDown;
            hitsTaken = 0;
        }

        if (shaking)
        {
            Vector3 newPos = originalPos + Random.insideUnitSphere * (Time.deltaTime * shakeAmt);
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;

            transform.position = newPos;
        }
    }

    void CreateOre()
    {
        Instantiate(ore, transform.position, Quaternion.identity);
        rend.enabled = false;
    }

    public void ShakeMe()
    {
        StopCoroutine("ShakeNow");
        StartCoroutine("ShakeNow");
    }

    IEnumerator ShakeNow()
    {

        if (shaking == false)
        {
            shaking = true;
        }

        yield return new WaitForSeconds(0.5f);

        shaking = false;
        transform.position = originalPos;
    }
     
}
