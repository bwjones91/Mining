using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OreList : MonoBehaviour {

    public List<Ore> ores = new List<Ore>();

    public Text runeCounterText;

    public Rigidbody mithrilOre;
    public Rigidbody adamantiteOre;
    public Rigidbody goldOre;
    public Rigidbody pyroniumOre;
    public Rigidbody silverOre;
    public Ore oreThrown;
    private bool shaking = false;

    private float shakeAmt = 50f;

    public AudioClip throwWhoosh;
    public OreSwitcher oreSwitcher;
    public OreList oreList;

    bool doorOpen;

    public int runeCounter;
    
    private Rigidbody instance;
    public AudioSource source;

    public GameController gameController;

	void Start () {
        doorOpen = false;
    }

    void Update () {
        if (shaking)
        {
            Vector3 newPos = transform.position + Random.insideUnitSphere * (Time.deltaTime * shakeAmt);
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;

            transform.position = newPos;
        }

        if (runeCounter == 3)
        {
            doorOpen = true;
            print(doorOpen);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Rock Attack")
        {
            ShakeMe();
            ThrowFunction();
        }
    }

    public void ThrowFunction()
    {
        if (ores.Count > 0)
        {
            int amountOreThrown = Random.Range(2, 4);
            GameObject theController = GameObject.Find("GameController");
            GameController gameController = theController.GetComponent<GameController>();
            for (int i = 0; i < amountOreThrown; i++)
            {
                oreThrown = ores[Random.Range(0, ores.Count)];
                Ore.OreType type = oreThrown.GetComponent<Ore>().oreType;
                switch (type)
                {
                    case Ore.OreType.Mithril:
                        instance = Instantiate(mithrilOre, transform.position + new Vector3(0f, 5f, 0f), Quaternion.identity);
                        InstantiateThrownOre();
                        gameController.mithrilCounter--;
                        break;
                    case Ore.OreType.Adamantite:
                        instance = Instantiate(adamantiteOre, transform.position + new Vector3(0f, 5f, 0f), Quaternion.identity);
                        InstantiateThrownOre();
                        gameController.adamantiteCounter--;
                        break;
                    case Ore.OreType.Gold:
                        instance = Instantiate(goldOre, transform.position + new Vector3(0f, 5f, 0f), Quaternion.identity);
                        InstantiateThrownOre();
                        gameController.goldCounter--;
                        break;
                    case Ore.OreType.Pyronium:
                        instance = Instantiate(pyroniumOre, transform.position + new Vector3(0f, 5f, 0f), Quaternion.identity);
                        InstantiateThrownOre();
                        gameController.pyroniumCounter--;
                        break;
                    case Ore.OreType.Silver:
                        instance = Instantiate(silverOre, transform.position + new Vector3(0f, 5f, 0f), Quaternion.identity);
                        InstantiateThrownOre();
                        gameController.silverCounter--;
                        break;
                }
            }
        }
        gameController.SetCurrentOreText();
    }

    public void InstantiateThrownOre()
    {
        instance.AddForce(new Vector3(Random.Range(-1500f, 1500f), 1500f, 0f));
        oreSwitcher.oresNeeded.Add(oreThrown.GetComponent<Ore>());
        ores.Remove(oreThrown.GetComponent<Ore>());
    }

    public void ThrowRepeating()
    {
        InvokeRepeating("ThrowFunction", 5f, 5f);
    }

    public void CancelThrowing()
    {
        CancelInvoke("ThrowFunction");
    }

    public void ShakeMe()
    {
        StopCoroutine("ShakeNow");
        StartCoroutine("ShakeNow");
    }

    IEnumerator ShakeNow()
    {

        if (shaking == false)
        {
            shaking = true;
        }

        yield return new WaitForSeconds(0.2f);

        shaking = false;
    }

    public void OreClear()
    {
        ores.Clear();
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
