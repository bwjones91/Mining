using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollController : MonoBehaviour {
    
    public enum Action
    {
        Move,
        Rotate,
        Attack
    }

    public TrollMove trollMove;
    public TrollRotate trollRotate;

	void Start () {
        Invoke("MoveTroll", 3f);
	}

    void Update() {

    }

    public void MoveTroll()
    {
        trollMove.TrollPositionDecider();
    }

}
