using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OreList : MonoBehaviour {

    public List<Ore> ores = new List<Ore>();

    public Text mithrilNeededText;
    public Text adamantiteNeededText;
    public Text goldNeededText;
    public Text pyroniumNeededText;
    public Text silverNeededText;
    public Text grapiteNeededText;


    public Text runeCounterText;

    public Rigidbody mithrilOre;
    public Rigidbody adamantiteOre;
    public Rigidbody goldOre;
    public Rigidbody pyroniumOre;
    public Rigidbody silverOre;
    public Rigidbody grapiteOre;

    int mithrilNeeded;
    int adamantiteNeeded;
    int goldNeeded;
    int pyroniumNeeded;
    int silverNeeded;
    int grapiteNeeded;
    bool doorOpen;

    public int runeCounter;

    private Rigidbody instance;

    public GameController gameController;

	void Start () {
        OresNeeded();
        SetNeededText();
        doorOpen = false;
    }

    void Update () {
        if(runeCounter == 3)
        {
            doorOpen = true;
            print(doorOpen);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject theController = GameObject.Find("GameController");
        GameController gameController = theController.GetComponent<GameController>();
        if (collider.gameObject.tag == "Dropoff Zone")
        {

            if (gameController.mithrilCounter >= mithrilNeeded && 
                gameController.adamantiteCounter >= adamantiteNeeded &&
                gameController.goldCounter >= goldNeeded &&
                gameController.pyroniumCounter >= pyroniumNeeded &&
                gameController.silverCounter >= silverNeeded &&
                gameController.grapiteCounter >= grapiteNeeded)
            {
                OffLoading();
                gameController.mithrilCounter = 0;
                gameController.adamantiteCounter = 0;
                gameController.goldCounter = 0;
                gameController.pyroniumCounter = 0;
                gameController.silverCounter = 0;
                gameController.grapiteCounter = 0;
                print("Success");

            }
            
        }
    }



    void SetNeededText()
    {
        mithrilNeededText.text = mithrilNeeded.ToString();
        adamantiteNeededText.text = adamantiteNeeded.ToString();
        goldNeededText.text = goldNeeded.ToString();
        pyroniumNeededText.text = pyroniumNeeded.ToString();
        silverNeededText.text = silverNeeded.ToString();
        grapiteNeededText.text = grapiteNeeded.ToString();
    }

    public void OresNeeded()
    {
        mithrilNeeded = Random.Range(4, 6);
        adamantiteNeeded = Random.Range(3, 4);
        goldNeeded = Random.Range(1, 2);
        pyroniumNeeded = Random.Range(3, 5);
        silverNeeded = Random.Range(2, 3);
        grapiteNeeded = 20 - (mithrilNeeded + adamantiteNeeded + goldNeeded + pyroniumNeeded + silverNeeded);
        print("Mithril Needed" + mithrilNeeded);
        print("Adamantite Needed" + adamantiteNeeded);
        print("Gold Needed" + goldNeeded);
        print("Pyronium Needed" + pyroniumNeeded);
        print("Silver Needed" + silverNeeded);
        print("Grapite Needed" + grapiteNeeded);
    }

    public void ThrowFunction()
    {
        if (ores.Count > 0)
        {
            GameObject theController = GameObject.Find("GameController");
            GameController gameController = theController.GetComponent<GameController>();
            var oreThrown = ores[Random.Range(0, ores.Count)];

            switch (oreThrown.oreType)
            {
                case Ore.OreType.Mithril:
                    instance = Instantiate(mithrilOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                    instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
                    gameController.mithrilCounter--;
                    break;
                case Ore.OreType.Adamantite:
                    instance = Instantiate(adamantiteOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                    instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
                    gameController.adamantiteCounter--;
                    break;
                case Ore.OreType.Gold:
                    instance = Instantiate(goldOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                    instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
                    gameController.goldCounter--;
                    break;
                case Ore.OreType.Pyronium:
                    instance = Instantiate(pyroniumOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                    instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
                    gameController.pyroniumCounter--;
                    break;
                case Ore.OreType.Silver:
                    instance = Instantiate(silverOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                    instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
                    gameController.silverCounter--;
                    break;
                case Ore.OreType.Grapite:
                    instance = Instantiate(grapiteOre, transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
                    instance.AddForce(new Vector3(Random.Range(-500f, 500f), 250f, 0f));
                    gameController.grapiteCounter--;
                    break;
            }

            ores.Remove(oreThrown);
        }
        gameController.SetCurrentOreText();
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
        OresNeeded();
        SetNeededText();
        runeCounter++;
        runeCounterText.text = "Runes: " + runeCounter.ToString();
        gameController.SetCurrentOreText();
    }

    public void OffLoading()
    {
        Invoke("OreClear", 0.5f);
        gameController.SetCurrentOreText();
    }
}
