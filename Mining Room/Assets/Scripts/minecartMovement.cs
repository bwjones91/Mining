using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minecartMovement : MonoBehaviour {
    
    public float  minecartSpeed;
    public float speedToThrowGoblin;
    public float chanceToSpawn;
    public GameObject goblin;
    public OreList oreList;
    public GoblinThrow goblinThrowing;
    public GameController gameController;
    public float thrustVariable;
    public float localSpeed;
    public float maxSpeed;

    private float thrust;
    private bool right;
    private float thrustDirection;
    //private float touchCount;
    private float goblinSpawnChance;
    private int goblinsOnScreen;
    private GameObject newGoblin;
    //private bool leftButton;
    //private bool rightButton;
    private float leverMovement;
    private ArduinoCommunicator AC;
    private float force;
    private Rigidbody rb;
    private bool speedLimiterLeft;
    


    void Start () {
        rb = this.GetComponent<Rigidbody>();
        AC = GameObject.Find("Arduino Communication").GetComponent<ArduinoCommunicator>();
        thrustDirection = -1f;
        speedLimiterLeft = true;
	}

	void Update () {
        leverMovement = Mathf.Abs(AC.GetMessageIN());

        minecartSpeed = GetComponent<Rigidbody>().velocity.magnitude;
        var localSpeed = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
        

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speedLimiterLeft = true;
            if (localSpeed.x > -maxSpeed)
            {
                thrustDirection = -1f;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && localSpeed.x < maxSpeed)
        {
            speedLimiterLeft = false;
            if (localSpeed.x < maxSpeed)
            {
                thrustDirection = 1f;
            }
        }

        if (localSpeed.x >= maxSpeed && speedLimiterLeft == false)
        {
            thrustDirection = 0f;
        }

        if (localSpeed.x <= -maxSpeed && speedLimiterLeft == true)
        {
            thrustDirection = 0f;
        }

        /*if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            right = !right;
        }

        if(right == true)
        {
            thrustDirection = 1f;
        }
        else
        {
            thrustDirection = -1f;
        }      */

        /*if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftButton = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightButton = true;
        }*/
    }

    private void FixedUpdate()
    {
        /*if (leftButton == true && touchCount < 1)
        {
            thrust = Random.Range(10, 20);
            GetComponent<Rigidbody>().AddForce(new Vector3(thrustDirection, 0f, 0f) * thrust);
            touchCount++;
            leftButton = false;
        }

        if(rightButton == true && touchCount > 0)
        {
            thrust = Random.Range(10, 20);
            GetComponent<Rigidbody>().AddForce(new Vector3(thrustDirection, 0f, 0f) * thrust);
            touchCount--;
            rightButton = false;
        }*/

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
            thrust = (leverMovement) * thrustVariable;
            rb.AddForce(new Vector3(thrustDirection, 0f, 0f) * thrust);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(((collision.gameObject.tag == "Left Wall") || (collision.gameObject.tag == "Right Wall")) && minecartSpeed > speedToThrowGoblin && goblinsOnScreen > 0)
        {
            oreList.CancelThrowing();
            goblinsOnScreen--;

            if(collision.gameObject.tag == "Left Wall")
            {
                goblinThrowing.GoblinLeftThrow();
            }
            else
            {
                goblinThrowing.GoblinRightThrow();
            }
        }

        if(collision.gameObject.tag == "Left Wall" || collision.gameObject.tag == "Right Wall")
        {
            minecartSpeed = 0;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject theController = GameObject.Find("GameController");
        GameController gameController = theController.GetComponent<GameController>();
        if (collider.gameObject.tag == "Ore")
        {
            Ore.OreType type = collider.gameObject.GetComponent<Ore>().oreType;
            switch (type)
            {
                case Ore.OreType.Mithril:
                    gameController.mithrilCounter++;
                    break;
                case Ore.OreType.Adamantite:
                    gameController.adamantiteCounter++;
                    break;
                case Ore.OreType.Gold:
                    gameController.goldCounter++;
                    break;
                case Ore.OreType.Pyronium:
                    gameController.pyroniumCounter++;
                    break;
                case Ore.OreType.Silver:
                    gameController.silverCounter++;
                    break;
                case Ore.OreType.Grapite:
                    gameController.grapiteCounter++;
                    break;
            }

            goblinSpawnChance = Random.Range(0f, 100f);
            if(goblinSpawnChance <= chanceToSpawn && goblinsOnScreen < 1)
            {
                newGoblin = Instantiate(goblin, transform.position, goblin.transform.rotation);
                newGoblin.transform.parent = gameObject.transform;
                goblinThrowing = GetComponentInChildren<GoblinThrow>();
                goblinsOnScreen++;
                oreList.ThrowRepeating();
            }

        }
        gameController.SetCurrentOreText();
    }


}
