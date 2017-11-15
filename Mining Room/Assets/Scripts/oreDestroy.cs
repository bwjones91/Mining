using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oreDestroy : MonoBehaviour {

    public enum OreType
    {
        Coal,
        Copper,
        Gold,
        Iron,
        Silver,
        Tin
    }

    public OreType oreType;

	void Start () {
        
	}
	
	void Update () {
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject theController = GameObject.Find("GameController");
        GameController gameController = theController.GetComponent<GameController>();
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            switch (oreType)
            {
                case OreType.Coal:
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
    }

}
