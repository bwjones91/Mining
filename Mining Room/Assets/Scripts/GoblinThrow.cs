using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinThrow : MonoBehaviour {
    

    private Rigidbody rb;

    private CameraShake cameraShaking;

	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        GameObject minecart = GameObject.FindGameObjectWithTag("Player");
        FixedJoint fj;
        fj = this.gameObject.AddComponent<FixedJoint>();
        fj.connectedBody = minecart.GetComponent<Rigidbody>();
        cameraShaking = GameObject.FindGameObjectWithTag("Camera Parent").GetComponent<CameraShake>();
	}
	
	void Update () {
		
	}

    public void GoblinLeftThrow()
    {
        transform.parent = null;
        var joint = gameObject.GetComponent<FixedJoint>();
        Destroy(joint);
        rb.mass = 1;
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(new Vector3(-3000f, 800f, 0f));
        rb.AddTorque(0, 0, 200f);
        cameraShaking.ShakeCamera(1.5f, .5f);
        Destroy(gameObject, 5);
    }

    public void GoblinRightThrow()
    {
        transform.parent = null;
        var joint = gameObject.GetComponent<FixedJoint>();
        Destroy(joint);
        rb.mass = 1;
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(new Vector3(3000f, 800f, 0f));
        rb.AddTorque(0, 0, -200f);
        cameraShaking.ShakeCamera(1.5f, .5f);
        Destroy(gameObject, 5);
    }

}
