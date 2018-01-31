using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChildDetachment : MonoBehaviour {

    public Transform myCameraObject;

    public GameObject funnel;
    public GameObject funnelFloor;
    public GameObject spotLight;

    void Start() {

    }

    void Update() {



	}

    private void OnTriggerEnter(Collider other)
    {
        myCameraObject.parent = null;
        funnel.transform.position = new Vector3(225.5f, 234f, 35.3f);
        funnelFloor.SetActive(false);
        spotLight.SetActive(true);
    }

}
