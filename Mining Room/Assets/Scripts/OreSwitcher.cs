using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreSwitcher : MonoBehaviour {

    public List<Ore> oresNeeded = new List<Ore>();

    public GameObject mithrilDisplayOre;
    public GameObject adamantiteDisplayOre;
    public GameObject goldDisplayOre;
    public GameObject pyroniumDisplayOre;
    public GameObject silverDisplayOre;

    public Material mithrilDisplayMaterial;
    public Material adamantiteDisplayMaterial;
    public Material goldDisplayMaterial;
    public Material pyroniumDisplayMaterial;
    public Material silverDisplayMaterial;

    private Material oreToFade;
    private Color alphaColorStart;
    private Color alphaColorFinish;
    private float startTime;
    private float targetTime;
    private float timeToFade = 5.0f;
    private bool isLerp = false;

    public Rigidbody mithrilOre;
    public Rigidbody adamantiteOre;
    public Rigidbody goldOre;
    public Rigidbody pyroniumOre;
    public Rigidbody silverOre;

    public GameObject mithrilPermanentOre;
    public GameObject adamantitePermanentOre;
    public GameObject goldPermanentOre;
    public GameObject pyroniumPermanentOre;
    public GameObject silverPermanentOre;
    

    private GameObject permanentOreInstance;

    int mithrilNeeded;
    int adamantiteNeeded;
    int goldNeeded;
    int pyroniumNeeded;
    int silverNeeded;

	void Start () {
        Invoke("DisplayOre", 2f);
        OresNeeded();
	}
	
	void Update () {
        var progress = Time.time - startTime;

        if (isLerp)
        {
            oreToFade.color = Color.Lerp(alphaColorStart, alphaColorFinish, progress / timeToFade);
            permanentOreInstance.GetComponent<oreSpawn>().enabled = true;
            if (timeToFade < progress)
            {
                isLerp = false;
                permanentOreInstance.GetComponent<oreSpawn>().enabled = false;
                permanentOreInstance.SetActive(false);
                Invoke("DisplayOre", .2f);
            }
        }

        
    }

    public void OresNeeded()
    {
        mithrilNeeded = Random.Range(3, 5);
        adamantiteNeeded = Random.Range(3, 4);
        goldNeeded = Random.Range(3, 5);
        pyroniumNeeded = Random.Range(3, 5);
        silverNeeded = 20 - (mithrilNeeded + adamantiteNeeded + goldNeeded + pyroniumNeeded);
        for (int i = 0; i < mithrilNeeded; i++)
        {
            oresNeeded.Add(mithrilOre.GetComponent<Ore>());
        }
        for (int i = 0; i < adamantiteNeeded; i++)
        {
            oresNeeded.Add(adamantiteOre.GetComponent<Ore>());
        }
        for (int i = 0; i < goldNeeded; i++)
        {
            oresNeeded.Add(goldOre.GetComponent<Ore>());
        }
        for (int i = 0; i < pyroniumNeeded; i++)
        {
            oresNeeded.Add(pyroniumOre.GetComponent<Ore>());
        }
        for (int i = 0; i < silverNeeded; i++)
        {
            oresNeeded.Add(silverOre.GetComponent<Ore>());
        }
    }

    public void DisplayOre()
    {
        var oreDisplayed = oresNeeded[Random.Range(0, oresNeeded.Count)];
        print(oreDisplayed);
        switch (oreDisplayed.oreType)
        {
            case Ore.OreType.Mithril:
                permanentOreInstance = mithrilPermanentOre;
                permanentOreInstance.SetActive(true);
                alphaColorStart = new Color(0.38f, 0.46f, 0.66f, 1f);
                alphaColorFinish = new Color(0.38f, 0.46f, 0.66f, 0f);
                oreToFade = mithrilDisplayMaterial;
                startTime = Time.time;
                isLerp = true;
                break;
            case Ore.OreType.Adamantite:
                permanentOreInstance = adamantitePermanentOre;
                permanentOreInstance.SetActive(true);
                alphaColorStart = new Color(0.03f, 0.44f, 0f, 1f);
                alphaColorFinish = new Color(0.03f, 0.44f, 0f, 0f);
                oreToFade = adamantiteDisplayMaterial;
                startTime = Time.time;
                isLerp = true;
                break;
            case Ore.OreType.Gold:
                permanentOreInstance = goldPermanentOre;
                permanentOreInstance.SetActive(true);
                alphaColorStart = new Color(1f, 0.84f, 0f, 1f);
                alphaColorFinish = new Color(1f, 0.84f, 0f, 0f);
                oreToFade = goldDisplayMaterial;
                startTime = Time.time;
                isLerp = true;
                break;
            case Ore.OreType.Pyronium:
                permanentOreInstance = pyroniumPermanentOre;
                permanentOreInstance.SetActive(true);
                alphaColorStart = new Color(1f, 0f, 0f, 1f);
                alphaColorFinish = new Color(4f, 0f, 0f, 0f);
                oreToFade = pyroniumDisplayMaterial;
                startTime = Time.time;
                isLerp = true;
                break;
            case Ore.OreType.Silver:
                permanentOreInstance = silverPermanentOre;
                permanentOreInstance.SetActive(true);
                alphaColorStart = new Color(0.75f, 0.75f, 0.75f, 1f);
                alphaColorFinish = new Color(0.75f, 0.75f, 0.75f, 0f);
                oreToFade = silverDisplayMaterial;
                startTime = Time.time;
                isLerp = true;
                break;
        }
    }

}
