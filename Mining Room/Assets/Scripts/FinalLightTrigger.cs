using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLightTrigger : MonoBehaviour
{

    public GameObject torch;
    public GameObject torch2;
    public GameObject torch3;
    public GameObject torch4;
    public GameObject torch5;
    public GameObject torch6;
    public GameObject torch7;
    public GameObject torch8;
    public GameObject torch9;
    public GameObject torch10;

    public float waitTime;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        torch.gameObject.SetActive(true);
        StartCoroutine(Wait());
        /*yield return new WaitForSeconds(waitTime);
        torch2.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        torch3.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        torch4.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        torch5.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        torch6.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        torch7.gameObject.SetActive(true);*/
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        torch2.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        torch3.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        torch4.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        torch5.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        torch6.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        torch7.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        torch8.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        torch9.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        torch10.gameObject.SetActive(true);
    }

}