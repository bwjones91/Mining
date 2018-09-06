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
    public AudioClip oreHitSound;
    public GameObject oreLight;
    public float hitThreshold = 12;

    private AudioSource source;
    private float hitsTaken;
    public float coolDownTimer;
    private bool veinLightUp;
    private bool shaking = false;
    private bool changeLight = false;
    private float lightMax;
    private float lightChange;

    private float hitAmount;
    private PiezoArduinoCommunicator AC;

    Vector3 originalPos;
    
    private float shakeAmt = 100f;

    void Awake() {
        source = GetComponent<AudioSource>();
    }

    void Start () {
        originalPos = transform.position;
        lightMax = thisLight.intensity;
        lightChange = lightMax / 12;
        AC = GameObject.Find("Piezo Arduino Communication").GetComponent<PiezoArduinoCommunicator>();
    }


    void Update () {
        print(AC.GetMessageIN());
        hitAmount = AC.GetMessageIN();
        print(hitAmount);

        if (hitAmount > hitThreshold)
        {
            hitsTaken++;
            ShakeMe();
            source.PlayOneShot(oreHitSound, 1f);
        }

        if (hitAmount > hitThreshold && hitsTaken >= hitsNeeded)
        {
            Invoke("CreateOre", 0f);
            veinLightUp = false;
            hitsTaken = 0;
            shaking = false;
            gameObject.SetActive(false);
        }

        if (shaking)
        {
            Vector3 newPos = originalPos + Random.insideUnitSphere * (Time.deltaTime * shakeAmt);
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;

            transform.position = newPos;
        }

        if(thisLight.intensity < lightMax)
        {
            thisLight.intensity += lightChange;
        }
    }

    void CreateOre()
    {
        Instantiate(ore, transform.position, Quaternion.identity);
        thisLight.intensity = 0f;
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
