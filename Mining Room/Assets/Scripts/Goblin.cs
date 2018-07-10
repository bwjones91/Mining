using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour {

    public bool isRunning;
    public float entranceSpeed = 50f;
    public float speed = 50f;
    public float turningSpeed = 60f;
    public float currentAttackPosition;
    public float targetAttackPosition;
    public GameObject rock;
    public float rockVelocity;

    public Transform startMarker;
    public Transform endMarker;
    public Transform startPosition;
    public Transform firstPosition;
    public Transform secondPosition;
    public Transform thirdPosition;
    public Transform fourthPosition;
    public Transform fifthPosition;

    Animator anim;
    private float attackStartTime;
    private float startTime;
    private float turnStartTime;
    private float journeyLength;
    private bool isEntrance = true;
    private bool turnFront = false;
    private bool attackMove = false;
    private bool attackTurn = false;
    private bool goblinStun = false;
    private Quaternion leftFaceRotation = Quaternion.Euler(0f, 90f, 0f);
    private Quaternion rightFaceRotation = Quaternion.Euler(0f, 270f, 0f);
    private Quaternion frontFaceRotation = Quaternion.Euler(0f, 180f, 0f);

	void Start () {
        isRunning = false;
        startPosition.position = new Vector3(-250f, 2f, 75f);
        firstPosition.position = new Vector3(-150f, 2f, 75f);
        secondPosition.position = new Vector3(-70f, 2f, 75f);
        thirdPosition.position = new Vector3(2f, 2f, 75f);
        fourthPosition.position = new Vector3(70f, 2f, 75f);
        fifthPosition.position = new Vector3(130f, 2f, 75f);
        startTime = Time.time;
        isRunning = true;
        Invoke("GoblinAttackPosition", 7f);
        anim = GetComponent<Animator>();
    }
	
	void Update () {

        anim.SetBool("Run", isRunning);

        if (isEntrance)
        {
            GoblinEntrance();

            if (gameObject.transform.position == thirdPosition.position)
            {
                isEntrance = false;
                turnFront = true;
                currentAttackPosition = 3;
            }
        }
        
        if (turnFront)
        {
            GoblinFaceFront();
            if(transform.rotation == frontFaceRotation)
            {
                attackMove = true;
                turnFront = false;
                isRunning = false;
            }
        }

        if (attackTurn)
        {
            if(currentAttackPosition < targetAttackPosition)
            {
                GoblinFaceLeft();
            }
            else if(currentAttackPosition > targetAttackPosition)
            {
                GoblinFaceRight();
            }

            if (attackMove)
            {
                journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
                float distanceCovered = (Time.time - attackStartTime) * speed;
                float fractionJourney = distanceCovered / journeyLength;
                gameObject.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionJourney);

                if (gameObject.transform.position == endMarker.position)
                {
                    RockAttack();
                    attackTurn = false;
                    attackMove = false;
                    currentAttackPosition = targetAttackPosition;
                    Invoke("GoblinAttackPosition", 2f);
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Ore")
        {
            goblinStun = true;
            Invoke("StunEnd", 10f);
        }
            
    }

    public void StunEnd()
    {
        goblinStun = false;
        GoblinAttackPosition();
    }

    public void RockAttack()
    {
        var clone = Instantiate(rock, transform.position + new Vector3(0, 30, 0), Quaternion.identity);
        clone.GetComponent<Rigidbody>().velocity = new Vector3(0, -50f, -rockVelocity);
    }

    public void GoblinAttackPosition()
    {
        if (goblinStun == false)
        {
            attackStartTime = Time.time;
            targetAttackPosition = Random.Range(1, 5);
            print(targetAttackPosition);
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
