﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChildDetachment : MonoBehaviour {

    public Transform myCameraObject;

    //public GameObject funnel;
    //public GameObject funnelFloor;
    public GameObject spotLight;
    public GameObject fallingRocks;
    public GameObject rightWall;

    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0f;
    private float startTime;
    private float journeyLength;

    private bool isLerp = false;
    private bool hasTriggered = false;

    void Start() {
        
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        fallingRocks.SetActive(false);
        rightWall.SetActive(false);
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
            //funnel.transform.position = new Vector3(225.5f, 234f, 35.3f);
            //funnelFloor.SetActive(false);
            fallingRocks.SetActive(true);
            rightWall.SetActive(true);

            startTime = Time.time;
            isLerp = true;
            hasTriggered = true;
        }
        

        //StartCoroutine(MoveSpotlight());
        //yield return new WaitForSeconds(2f);
        //spotLight.transform.position = new Vector3(234.4f, 234f, 72.5f);
    }

    void SpotlightPositionChanging()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        spotLight.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
    }

    /*IEnumerator MoveSpotlight()
    {
        yield return new WaitForSeconds(2f);
        spotLight.transform.position = new Vector3(234.4f, 234f, 72.5f);
    }*/

}
