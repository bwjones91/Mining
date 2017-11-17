using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minecartMovement : MonoBehaviour {

    public float thrust;

    public float  minecartSpeed;

    public float speedToThrowGoblin;

    float goblinSpawnChance;

    public float chanceToSpawn;

    public GameObject goblin;

    public OreList oreThrowing;

    int goblinsOnScreen;

    private GameObject newGoblin;

    void Start () {

	}

	void Update () {
        minecartSpeed = GetComponent<Rigidbody>().velocity.magnitude;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-1f, 0f, 0f) * thrust);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(1f, 0f, 0f) * thrust);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall" && minecartSpeed > speedToThrowGoblin)
        {
            //transform.DetachChildren();
            Destroy(newGoblin);
            oreThrowing.CancelThrowing();
            goblinsOnScreen--;
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
                case Ore.OreType.Coal:
                    gameController.coalCounter++;
                    break;
                case Ore.OreType.Copper:
                    gameController.copperCounter++;
                    break;
                case Ore.OreType.Gold:
                    gameController.goldCounter++;
                    break;
                case Ore.OreType.Iron:
                    gameController.ironCounter++;
                    break;
                case Ore.OreType.Silver:
                    gameController.silverCounter++;
                    break;
                case Ore.OreType.Tin:
                    gameController.tinCounter++;
                    break;
            }

            goblinSpawnChance = Random.Range(0f, 100f);
            print(goblinSpawnChance);
            if(goblinSpawnChance <= chanceToSpawn && goblinsOnScreen < 1)
            {
                newGoblin = Instantiate(goblin, transform.position, Quaternion.identity);
                newGoblin.transform.parent = gameObject.transform;
                goblinsOnScreen++;
                oreThrowing.ThrowRepeating();
            }

        }
    }

}
