using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreCatcher : MonoBehaviour
{

    public AmmoCounter ammoCounter;
    public int myAmmo;
    public Material myMaterial;

    private Material material;
    GameObject myCatcher;

    void Start()
    {
        myCatcher = this.gameObject;
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if(ammoCounter.currentAmmo == myAmmo)
        {
            material = myMaterial as Material;
            myCatcher.GetComponent<MeshRenderer>().material = material;
        }
        else
        {
            material = Resources.Load("White Material") as Material;
            myCatcher.GetComponent<MeshRenderer>().material = material;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Ore")
        {
            Ore.OreType type = collider.gameObject.GetComponent<Ore>().oreType;
            switch (type)
            {
                case Ore.OreType.Mithril:
                    ammoCounter.currentAmmo = 1;
                    break;
                case Ore.OreType.Adamantite:
                    ammoCounter.currentAmmo = 2;
                    break;
                case Ore.OreType.Gold:
                    ammoCounter.currentAmmo = 3;
                    break;
                case Ore.OreType.Pyronium:
                    ammoCounter.currentAmmo = 4;
                    break;
                case Ore.OreType.Silver:
                    ammoCounter.currentAmmo = 5;
                    break;
                case Ore.OreType.Grapite:
                    ammoCounter.currentAmmo = 6;
                    break;
            }

        }
        

    }
}
