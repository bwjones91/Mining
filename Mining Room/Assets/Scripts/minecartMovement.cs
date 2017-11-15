using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minecartMovement : MonoBehaviour {

    public float moveSpeed;

    public float thrust;

    void Start () {
        
	}


	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(-1f, 0f, 0f) * thrust);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(1f, 0f, 0f) * thrust);
        }
        
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        GameObject theController = GameObject.Find("GameController");
        GameController gameController = theController.GetComponent<GameController>();
        if (collision.gameObject.tag == "Ore")
        {
            switch (collision.gameObject.GetComponent<oreDe)
            {
                case oreDestroy.OreType.Coal:
                    gameController.coalCounter++;
                    break;
                case OreType.Copper:
                    gameController.copperCounter++;
                    break;
                case OreType.Gold:
                    gameController.goldCounter++;
                    break;
                case OreType.Iron:
                    gameController.ironCounter++;
                    break;
                case OreType.Silver:
                    gameController.silverCounter++;
                    break;
                case OreType.Tin:
                    gameController.tinCounter++;
                    break;
            }
            Destroy(this.gameObject);
            gameController.myScore++;
            print(gameController.myScore);
        }
    }*/

}
