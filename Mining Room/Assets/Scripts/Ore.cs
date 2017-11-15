using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour {

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

    OreList oreList;

	void Start () {
        oreList = GetComponent<OreList>();
        print("test");
    }
	
	void Update () {
        
	}

    private void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.tag == "Ground")
        {
            //Destroy(this.gameObject);
        }
        if (collider.gameObject.tag == "Player")
        {
            oreList.ores.Add(gameObject.GetComponent<Ore>());
            print(oreList.ores.Count);
        }
    }
        /*if (collider.gameObject.tag == "Player")
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
        }*/

}
