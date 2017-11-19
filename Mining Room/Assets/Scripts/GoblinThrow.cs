using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinThrow : MonoBehaviour {

    private Rigidbody rb;
    public minecartMovement minecartMovement;

	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        GameObject minecart = GameObject.FindGameObjectWithTag("Player");
        FixedJoint fj;
        fj = this.gameObject.AddComponent<FixedJoint>();
        fj.connectedBody = minecart.GetComponent<Rigidbody>();
	}
	
	void Update () {
		
	}

    public void GoblinLeftThrow()
    {
        var joint = gameObject.GetComponent<FixedJoint>();
        Destroy(joint);
        rb.mass = 1;
        rb.AddForce(new Vector3(-2000f, 1000f, 0f));
        Destroy(gameObject, 5);
    }

    public void GoblinRightThrow()
    {
        var joint = gameObject.GetComponent<FixedJoint>();
        Destroy(joint);
        rb.mass = 1;
        rb.AddForce(new Vector3(2000f, 1000f, 0f));
        Destroy(gameObject, 5);
    }

}
