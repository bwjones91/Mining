using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreList : MonoBehaviour {

    public List<Ore> ores = new List<Ore>();

    public Rigidbody coalOre;
    public Rigidbody copperOre;
    public Rigidbody goldOre;
    public Rigidbody ironOre;
    public Rigidbody silverOre;
    public Rigidbody tinOre;

    int coalNeeded;
    int copperNeeded;
    int goldNeeded;
    int ironNeeded;
    int silverNeeded;
    int tinNeeded;

    private Rigidbody instance;



	void Start () {
        OresNeeded();
    }

    void Update () {
            
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject theController = GameObject.Find("GameController");
        GameController gameController = theController.GetComponent<GameController>();
        if (collider.gameObject.tag == "Dropoff Zone")
        {
            /*foreach (Ore item in ores)
            {
                switch (item.oreType)
                {
                    case Ore.OreType.Coal:
                        coalCount++;
                        break;
                    case Ore.OreType.Copper:
                        copperCount++;
                        break;
                    case Ore.OreType.Gold:
                        goldCount++;
                        break;
                    case Ore.OreType.Iron:
                        ironCount++;
                        break;
                    case Ore.OreType.Silver:
                        silverCount++;
                        break;
                    case Ore.OreType.Tin:
                        tinCount++;
                        break;
                }
            }*/

            if (gameController.coalCounter >= coalNeeded && 
                gameController.copperCounter >= copperNeeded &&
                gameController.goldCounter >= goldNeeded &&
                gameController.ironCounter >= ironNeeded &&
                gameController.silverCounter >= silverNeeded &&
                gameController.tinCounter >= tinNeeded)
            {
                OffLoading();
                gameController.coalCounter = 0;
                gameController.copperCounter = 0;
                gameController.goldCounter = 0;
                gameController.ironCounter = 0;
                gameController.silverCounter = 0;
                gameController.tinCounter = 0;
                print("Success");
                OresNeeded();
            }
            else
            {
                print("You don't have the correct ores");
            }

            
        }
    }

    public void OresNeeded()
    {
        coalNeeded = Random.Range(3, 4);
        copperNeeded = Random.Range(4, 6);
        goldNeeded = Random.Range(1, 2);
        ironNeeded = Random.Range(3, 5);
        silverNeeded = Random.Range(2, 3);
        tinNeeded = 20 - (coalNeeded + copperNeeded + goldNeeded + ironNeeded + silverNeeded);
        print("Coal Needed" + coalNeeded);
        print("Copper Needed" + copperNeeded);
        print("Gold Needed" + goldNeeded);
        print("Iron Needed" + ironNeeded);
        print("Silver Needed" + silverNeeded);
        print("Tin Needed" + tinNeeded);
    }

    public void ThrowFunction()
    {
        GameObject theController = GameObject.Find("GameController");
        GameController gameController = theController.GetComponent<GameController>();
        var oreThrown = ores[Random.Range(0, ores.Count)];

        switch (oreThrown.oreType)
        {
            case Ore.OreType.Coal:
                instance = Instantiate(coalOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
                gameController.coalCounter--;
                break;
            case Ore.OreType.Copper:
                instance = Instantiate(copperOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
                gameController.copperCounter--;
                break;
            case Ore.OreType.Gold:
                instance = Instantiate(goldOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
                gameController.goldCounter--;
                break;
            case Ore.OreType.Iron:
                instance = Instantiate(ironOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
                gameController.ironCounter--;
                break;
            case Ore.OreType.Silver:
                instance = Instantiate(silverOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
                gameController.silverCounter--;
                break;
            case Ore.OreType.Tin:
                instance = Instantiate(tinOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
                gameController.tinCounter--;
                break;
        }

        ores.Remove(oreThrown);
    }

    public void ThrowRepeating()
    {
        InvokeRepeating("ThrowFunction", 1f, 5f);
    }

    public void CancelThrowing()
    {
        CancelInvoke("ThrowFunction");
    }

    public void OreClear()
    {
        ores.Clear();
    }

    public void OffLoading()
    {
        Invoke("OreClear", 1f);
    }
}
