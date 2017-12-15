using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour {

    public enum OreType
    {
        Mithril,
        Adamantite,
        Gold,
        Pyronium,
        Silver,
        Grapite
    }

    public OreType oreType;

    OreList oreList;
    

    void Start () {
    }
	
	void Update () {
        
	}

    private void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        if (collider.gameObject.tag == "Player")
        {
            oreList.ores.Add(gameObject.GetComponent<Ore>());
            Destroy(this.gameObject);
        }
    }
}
