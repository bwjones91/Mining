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

    private Rigidbody instance;

	void Start () {
		
	}

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var oreThrown = ores[Random.Range(0, ores.Count)];
            print(oreThrown.oreType);

            switch (oreThrown.oreType)
            {
                case Ore.OreType.Coal:
                    instance = Instantiate(coalOre, transform.position + new Vector3(0f, 10f, 0f), Quaternion.identity);
                    instance.AddForce(new Vector3(0f, 250f, 0f));
                    break;
                case Ore.OreType.Copper:
                    instance = Instantiate(copperOre, transform.position + new Vector3(0f, 10f, 0f), Quaternion.identity);
                    instance.AddForce(new Vector3(0f, 250f, 0f));
                    break;
                case Ore.OreType.Gold:
                    instance = Instantiate(goldOre, transform.position + new Vector3(0f, 10f, 0f), Quaternion.identity);
                    instance.AddForce(new Vector3(0f, 250f, 0f));
                    break;
                case Ore.OreType.Iron:
                    instance = Instantiate(ironOre, transform.position + new Vector3(0f, 10f, 0f), Quaternion.identity);
                    instance.AddForce(new Vector3(0f, 250f, 0f));
                    break;
                case Ore.OreType.Silver:
                    instance = Instantiate(silverOre, transform.position + new Vector3(0f, 10f, 0f), Quaternion.identity);
                    instance.AddForce(new Vector3(0f, 250f, 0f));
                    break;
                case Ore.OreType.Tin:
                    instance = Instantiate(tinOre, transform.position + new Vector3(0f, 10f, 0f), Quaternion.identity);
                    instance.AddForce(new Vector3(0f, 250f, 0f));
                    break;
            }

            ores.Remove(oreThrown);

            //Instantiate(ores[Random.Range(0, ores.Count)]);
        }
    }
}
