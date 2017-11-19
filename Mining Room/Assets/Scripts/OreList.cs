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
            
    }

    public void ThrowFunction()
    {
        var oreThrown = ores[Random.Range(0, ores.Count)];
        print(oreThrown.oreType);

        switch (oreThrown.oreType)
        {
            case Ore.OreType.Coal:
                instance = Instantiate(coalOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
                break;
            case Ore.OreType.Copper:
                instance = Instantiate(copperOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
                break;
            case Ore.OreType.Gold:
                instance = Instantiate(goldOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
                break;
            case Ore.OreType.Iron:
                instance = Instantiate(ironOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
                break;
            case Ore.OreType.Silver:
                instance = Instantiate(silverOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
                break;
            case Ore.OreType.Tin:
                instance = Instantiate(tinOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
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

    public void OffLoading()
    {
        var oreOffLoaded = ores[Random.Range(0, ores.Count)];
        ores.Remove(oreOffLoaded);
    }

    public void OffLoadingRepeating()
    {
        InvokeRepeating("OffLoading", 1f, 0.5f);
    }

    public void CancelOffLoadingRepeating()
    {
        CancelInvoke("OffLoading");
    }

}
