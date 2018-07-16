using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollMove : MonoBehaviour {

    public Transform startPosition;
    public Transform firstPosition;
    public Transform secondPosition;
    public Transform thirdPosition;
    public Transform fourthPosition;
    public Transform fifthPosition;

    public bool isMoving = false;
    public float currentAttackPosition;
    public float targetAttackPosition;
    public float turnDirection;
    public GameObject minecart;
    public Vector3 targetPosition;
    public TrollRotate trollRotate;

    Animator anim;

    void Start () {
        startPosition.position = new Vector3(-250f, 0f, 60f);
        firstPosition.position = new Vector3(-150f, 0f, 60f);
        secondPosition.position = new Vector3(-70f, 0f, 60f);
        thirdPosition.position = new Vector3(2f, 0f, 60f);
        fourthPosition.position = new Vector3(70f, 0f, 60f);
        fifthPosition.position = new Vector3(130f, 0f, 60f);
        currentAttackPosition = 0;
        anim = GetComponent<Animator>();
    }
	
	void Update () {
        anim.SetBool("Run", isMoving);
	}

    public void TrollMovement()
    {
        StartCoroutine(MoveTroll(gameObject, targetPosition, 1f));
        currentAttackPosition = targetAttackPosition;
    }

    public void TrollPositionDecider()
    {
        var positionOne = Mathf.Abs(minecart.transform.position.x - firstPosition.position.x);
        var positionTwo = Mathf.Abs(minecart.transform.position.x - secondPosition.position.x);
        var positionThree = Mathf.Abs(minecart.transform.position.x - thirdPosition.position.x);
        var positionFour = Mathf.Abs(minecart.transform.position.x - fourthPosition.position.x);
        var positionFive = Mathf.Abs(minecart.transform.position.x - fifthPosition.position.x);
        var decider = Mathf.Min(positionOne, positionTwo, positionThree, positionFour, positionFive);
        if (decider == positionOne)
        {
            targetAttackPosition = 1;
            targetPosition = firstPosition.transform.position;
        }
        else if (decider == positionTwo)
        {
            targetAttackPosition = 2;
            targetPosition = secondPosition.transform.position;
        }
        else if (decider == positionThree)
        {
            targetAttackPosition = 3;
            targetPosition = thirdPosition.transform.position;
        }
        else if (decider == positionFour)
        {
            targetAttackPosition = 4;
            targetPosition = fourthPosition.transform.position;
        }
        else if (decider == positionFive)
        {
            targetAttackPosition = 5;
            targetPosition = fifthPosition.transform.position;
        }

        turnDirection = targetAttackPosition - currentAttackPosition;
        trollRotate.TrollTurn();
    }

    IEnumerator MoveTroll(GameObject gameObject, Vector3 targetPosition, float duration)
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

        Vector3 currentPosition = gameObject.transform.position;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp(currentPosition, targetPosition, counter / duration);
            yield return null;
        }
        isMoving = false;

        trollRotate.TrollTurnForward();

    }
}
