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

    private float thrust;
    private bool right;
    public float thrustDirection;
    private float touchCount;
    private float goblinSpawnChance;
    private int goblinsOnScreen;
    private GameObject newGoblin;
    private bool leftButton;
    private bool rightButton;



    void Start () {

	}

	void Update () {
        minecartSpeed = GetComponent<Rigidbody>().velocity.magnitude;

        if(Input.GetKeyDown(KeyCode.DownArrow))
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
        }        

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftButton = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightButton = true;
        }
    }

    private void FixedUpdate()
    {
        if (leftButton == true && touchCount < 1)
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
        }
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
