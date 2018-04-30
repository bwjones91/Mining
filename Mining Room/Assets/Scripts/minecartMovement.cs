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
    public OreSwitcher oreSwitcher;

    public Rigidbody mithrilOre;
    public Rigidbody adamantiteOre;
    public Rigidbody goldOre;
    public Rigidbody pyroniumOre;
    public Rigidbody silverOre;
    public Rigidbody grapiteOre;

    private float thrust;
    private bool right;
    private float thrustDirection;
    private float goblinSpawnChance;
    private int goblinsOnScreen;
    private GameObject newGoblin;
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
        
        if(localSpeed.x < maxSpeed && speedLimiterLeft == false)
        {
            thrustDirection = 1f;
        }

        if (localSpeed.x > -maxSpeed && speedLimiterLeft == true)
        {
            thrustDirection = -1f;
        }

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
        
        
    }

    private void FixedUpdate()
    {
        thrust = (leverMovement) * thrustVariable;
        rb.AddForce(new Vector3(thrustDirection, 0f, 0f) * thrust);
        
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
                    oreSwitcher.oresNeeded.Remove(mithrilOre.GetComponent<Ore>());
                    break;
                case Ore.OreType.Adamantite:
                    gameController.adamantiteCounter++;
                    oreSwitcher.oresNeeded.Remove(adamantiteOre.GetComponent<Ore>());
                    break;
                case Ore.OreType.Gold:
                    gameController.goldCounter++;
                    oreSwitcher.oresNeeded.Remove(goldOre.GetComponent<Ore>());
                    break;
                case Ore.OreType.Pyronium:
                    gameController.pyroniumCounter++;
                    oreSwitcher.oresNeeded.Remove(pyroniumOre.GetComponent<Ore>());
                    break;
                case Ore.OreType.Silver:
                    gameController.silverCounter++;
                    oreSwitcher.oresNeeded.Remove(silverOre.GetComponent<Ore>());
                    break;
                case Ore.OreType.Grapite:
                    gameController.grapiteCounter++;
                    oreSwitcher.oresNeeded.Remove(grapiteOre.GetComponent<Ore>());
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
