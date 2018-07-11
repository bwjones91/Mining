using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour {

    public bool isRunning;
    public bool isAttacking;
    public bool oneAttacking;
    public bool twoAttacking;
    public float entranceSpeed = 50f;
    public float speed = 50f;
    public float turningSpeed = 60f;
    public float currentAttackPosition;
    public float targetAttackPosition;
    public float attackSpeed;
    public GameObject attackOneCollider;
    public GameObject attackTwoCollider;

    public Transform startMarker;
    public Transform endMarker;
    public Transform startPosition;
    public Transform firstPosition;
    public Transform secondPosition;
    public Transform thirdPosition;
    public Transform fourthPosition;
    public Transform fifthPosition;

    public Transform attackStartPosition;
    public Transform attackEndPosition;
    public Transform defaultAttackPosition;

    Animator anim;
    private GameObject attackCollider;
    private float attackStartTime;
    private float moveStartTime;
    private float startTime;
    private float turnStartTime;
    private float journeyLength;
    private float distanceCovered;
    private float fractionJourney;
    private float attackJourneyLength;
    private float attackDistanceCovered;
    private float attackFractionJourney;
    private bool isEntrance = true;
    private bool turnFront = false;
    private bool attackMove = false;
    private bool attackTurn = false;
    private Quaternion leftFaceRotation = Quaternion.Euler(0f, 90f, 0f);
    private Quaternion rightFaceRotation = Quaternion.Euler(0f, 270f, 0f);
    private Quaternion frontFaceRotation = Quaternion.Euler(0f, 180f, 0f);

	void Start () {
        isRunning = false;
        startPosition.position = new Vector3(-250f, 2f, 70f);
        firstPosition.position = new Vector3(-150f, 2f, 70f);
        secondPosition.position = new Vector3(-70f, 2f, 70f);
        thirdPosition.position = new Vector3(2f, 2f, 70f);
        fourthPosition.position = new Vector3(70f, 2f, 70f);
        fifthPosition.position = new Vector3(130f, 2f, 70f);
        defaultAttackPosition.localPosition = new Vector3(0, 3, 0);
        attackTwoCollider.transform.localPosition = defaultAttackPosition.localPosition;
        startTime = Time.time;
        isRunning = true;
        Invoke("GoblinAttackPosition", 7f);
        anim = GetComponent<Animator>();
    }
	
	void Update () {

        anim.SetBool("Run", isRunning);
        anim.SetBool("AttackOne", oneAttacking);
        anim.SetBool("AttackTwo", twoAttacking);

        if (isEntrance)
        {
            GoblinEntrance();

            if (gameObject.transform.position == thirdPosition.position)
            {
                isEntrance = false;
                //turnFront = true;
                currentAttackPosition = 3;
                isRunning = false;
                AttackTwo();
            }
        }
        
        /*if (turnFront)
        {
            GoblinFaceFront();
            if(transform.rotation == frontFaceRotation)
            {
                //attackMove = true;
                turnFront = false;
                isRunning = false;
                AttackOne();
            }
        }*/
        
            if (attackMove)
            {
                isRunning = true;
                journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
                distanceCovered = (Time.time - moveStartTime) * speed;
                fractionJourney = distanceCovered / journeyLength;
                gameObject.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionJourney);

                if (gameObject.transform.position == endMarker.position)
                {
                    attackTurn = false;
                    attackMove = false;
                    isRunning = false;
                    currentAttackPosition = targetAttackPosition;
                    Invoke("GoblinAttackPosition", 3f);
                    var attackDecider = Random.Range(1, 3);
                    print(attackDecider);
                    if(attackDecider == 1)
                    {
                        AttackOne();
                    }
                    else
                    {
                        AttackTwo();
                    }
                }
            }

        if (isAttacking)
        {
            attackJourneyLength = Vector3.Distance(attackStartPosition.localPosition, attackEndPosition.localPosition);
            attackDistanceCovered = (Time.time - attackStartTime) * attackSpeed;
            attackFractionJourney = attackDistanceCovered / attackJourneyLength;
            attackCollider.transform.localPosition = Vector3.Lerp(attackStartPosition.localPosition, attackEndPosition.localPosition, attackFractionJourney);
            if(attackCollider.transform.localPosition == attackEndPosition.localPosition)
            {
                isAttacking = false;
                oneAttacking = false;
                twoAttacking = false;
                attackCollider.SetActive(false);
                attackCollider.transform.localPosition = defaultAttackPosition.localPosition;
            }
        }
        
    }

    public void AttackOne()
    {
        attackOneCollider.SetActive(true);
        attackCollider = attackOneCollider;
        isAttacking = true;
        oneAttacking = true;
        attackStartTime = Time.time;
        attackStartPosition.localPosition = new Vector3(0, 2.5f, 0);
        attackEndPosition.localPosition = new Vector3(0, 0, 0);
    }

    public void AttackTwo()
    {
        attackTwoCollider.SetActive(true);
        attackCollider = attackTwoCollider;
        isAttacking = true;
        twoAttacking = true;
        attackStartTime = Time.time;
        attackStartPosition.localPosition = new Vector3(0, 2.5f, 0);
        attackEndPosition.localPosition = new Vector3(0, 0, 0);
    }

    public void GoblinAttackPosition()
    {
        attackMove = true;
        moveStartTime = Time.time;
        targetAttackPosition = Random.Range(1, 5);
        if (targetAttackPosition == 1)
        {
            startMarker.position = gameObject.transform.position;
            endMarker.position = firstPosition.position;
        }
        else if (targetAttackPosition == 2)
        {
            startMarker.position = gameObject.transform.position;
            endMarker.position = secondPosition.position;
        }
        else if (targetAttackPosition == 3)
        {
            startMarker.position = gameObject.transform.position;
            endMarker.position = thirdPosition.position;
        }
        else if (targetAttackPosition == 4)
        {
            startMarker.position = gameObject.transform.position;
            endMarker.position = fourthPosition.position;
        }
        else if (targetAttackPosition == 5)
        {
            startMarker.position = gameObject.transform.position;
            endMarker.position = fifthPosition.position;
        }
        attackTurn = true;
    }

    void GoblinEntrance()
    {
        journeyLength = Vector3.Distance(startPosition.position, thirdPosition.position);
        float distanceCovered = (Time.time - startTime) * entranceSpeed;
        float fractionJourney = distanceCovered / journeyLength;
        gameObject.transform.position = Vector3.Lerp(startPosition.position, thirdPosition.position, fractionJourney);
    }

    void GoblinFaceLeft()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, leftFaceRotation, turningSpeed * Time.deltaTime);
    }

    void GoblinFaceFront()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, frontFaceRotation, turningSpeed * Time.deltaTime);
    }

    void GoblinFaceRight()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rightFaceRotation, turningSpeed * Time.deltaTime);
    }

    public void SetBlendedEulerAngles(Vector3 angles)
    {
        frontFaceRotation = Quaternion.Euler(angles);
        leftFaceRotation = Quaternion.Euler(angles);
        rightFaceRotation = Quaternion.Euler(angles);
    }

}
