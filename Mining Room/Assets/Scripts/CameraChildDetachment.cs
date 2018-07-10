using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChildDetachment : MonoBehaviour {

    public Transform myCameraObject;
    
    public GameObject spotLight;
    public GameObject fallingRocks;
    public GameObject rightWall;
    public AudioClip caveInSound;

    public GameObject gameController;
    public GameObject goblin;
    
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0f;

    private AudioSource source;
    private float startTime;
    private float journeyLength;

    private bool isLerp = false;
    private bool hasTriggered = false;

    void Start() {
        
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        fallingRocks.SetActive(false);
        rightWall.SetActive(false);
        source = GetComponent<AudioSource>();
    }

    void Update() {
        if (isLerp)
        {
            SpotlightPositionChanging();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered == false)
        {
            myCameraObject.parent = null;
            fallingRocks.SetActive(true);
            rightWall.SetActive(true);
            source.PlayOneShot(caveInSound, 1f);

            startTime = Time.time;
            isLerp = true;
            hasTriggered = true;
            gameController.GetComponent<OreSwitcher>().enabled = true;
            goblin.SetActive(true);
        }
    }

    void SpotlightPositionChanging()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        spotLight.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
    }
}
