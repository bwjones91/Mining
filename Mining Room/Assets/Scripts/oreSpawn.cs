using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oreSpawn : MonoBehaviour {

    public Rigidbody ore;
    public KeyCode theKey;
    public float coolDown;
    public float hitsNeeded;
    public Renderer rend;
    public GameObject coloredLight;
    public Light thisLight;
    
    private float hitsTaken;
    private float coolDownTimer;
    private bool veinLightUp;
    private bool shaking = false;
    private bool changeLight = false;
    private float lightMax;
    private float lightChange;

    //private ObjectShake objectShaking;
    Vector3 originalPos;
    
    private float shakeAmt = 100f;
    

    void Start () {
        rend.enabled = true;
        originalPos = transform.position;
        lightMax = thisLight.intensity;
        lightChange = lightMax / 12;
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

        /*if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
            rend.enabled = true;
            veinLightUp = true;
            //coloredLight.SetActive(true);
            changeLight = false;
        }*/

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

        /*if(changeLight && thisLight.intensity >= 0)
        {
            thisLight.intensity -= lightChange;
            //thisLight.intensity = 0f;
        }*/

        if(changeLight == false && thisLight.intensity < lightMax)
        {
            thisLight.intensity += lightChange;
        }
    }

    void CreateOre()
    {
        Instantiate(ore, transform.position, Quaternion.identity);
        rend.enabled = false;
        thisLight.intensity = 0f;
        //coloredLight.SetActive(false);
        changeLight = true;
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
