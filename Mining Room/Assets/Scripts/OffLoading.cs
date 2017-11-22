using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffLoading : MonoBehaviour {


    public OreList oreList;

    void Start () {
        oreList = GetComponent<OreList>();
	}
	
	void Update () {
		
	}

   

    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            oreList.CancelOffLoadingRepeating();
        }
    }*/

}
