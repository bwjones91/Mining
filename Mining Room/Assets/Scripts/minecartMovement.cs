using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minecartMovement : MonoBehaviour {

    public float thrust;

    public float  minecartSpeed;

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
            gameController.myScore++;
            //print(gameController.myScore);
        }
    }

}
