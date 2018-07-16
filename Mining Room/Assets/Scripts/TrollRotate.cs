using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollRotate : MonoBehaviour {

    public bool isTurning = false;
    public TrollMove trollMove;
    public TrollController trollController;
    public TrollAttack trollAttack;
    public Quaternion targetRotation;

    private Quaternion leftFaceRotation = Quaternion.Euler(0f, 90f, 0f);
    private Quaternion rightFaceRotation = Quaternion.Euler(0f, 270f, 0f);
    private Quaternion frontFaceRotation = Quaternion.Euler(0f, 180f, 0f);

    void Start () {
		
	}
	
	void Update () {
		
	}

    public void TrollAttackBegin()
    {
        trollAttack.AttackDecider();
    }

    public void TrollTurn()
    {
        if(trollMove.turnDirection < 0)
        {
            targetRotation = rightFaceRotation;
            StartCoroutine(RotateTroll(gameObject, targetRotation, .25f));
        }
        else if(trollMove.turnDirection > 0)
        {
            targetRotation = leftFaceRotation;
            StartCoroutine(RotateTroll(gameObject, targetRotation, .25f));
        }
        else if(trollMove.turnDirection == 0)
        {
            Invoke("TrollAttackBegin", 1f);
        }
    }

    public void TrollTurnLeft()
    {
        targetRotation = leftFaceRotation;
        StartCoroutine(RotateTroll(gameObject, targetRotation, .25f));
    }

    public void TrollTurnRight()
    {
        targetRotation = rightFaceRotation;
        StartCoroutine(RotateTroll(gameObject, targetRotation, .25f));
    }

    public void TrollTurnForward()
    {
        targetRotation = frontFaceRotation;
        StartCoroutine(RotateTroll(gameObject, targetRotation, .25f));
        trollAttack.AttackDecider();
        //Invoke("TrollAttackBegin", 1f);
    }

    IEnumerator RotateTroll(GameObject gameObject, Quaternion targetRotation, float duration)
    {
        if (isTurning)
        {
            yield break;
        }
        isTurning = true;

        Quaternion currentRotation = gameObject.transform.rotation;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            gameObject.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, counter / duration);
            yield return null;
        }
        isTurning = false;

        if(targetRotation != frontFaceRotation)
        {
            trollMove.TrollMovement();
        }
    }

}
