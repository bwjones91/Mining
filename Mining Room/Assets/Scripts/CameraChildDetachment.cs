using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChildDetachment : MonoBehaviour {

    public Transform myCameraObject;

    void Start() {

    }

    void Update() {



	}

    private void OnTriggerEnter(Collider other)
    {
        myCameraObject.parent = null;
    }

}
