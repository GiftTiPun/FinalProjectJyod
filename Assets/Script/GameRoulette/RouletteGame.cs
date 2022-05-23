using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteGame : MonoBehaviour
{
    public GameObject collider1_1;
    public GameObject collider1_2;
    public GameObject collider2_1;
    public GameObject collider2_2;

    public float randomnum;
    
    public void StartGame()
    {
        //check player id
        //wrap player to start game position
        //count down from 10
        //random
        //checkresult
        //wrap player to position
    }
    public void randomRouette()
    {
        randomnum = Random.Range(1f, 2f);
        Debug.Log("Roulette : " + randomnum);
    }
    void checkresut(float result)
    {
        if (result == 1)
        {
            collider1_2.SetActive(true);
            collider2_1.SetActive(true);
            StartCoroutine(end());
        }
        else
        {
            collider1_1.SetActive(true);
            collider2_2.SetActive(true);
            StartCoroutine(end());
        }
    }
    IEnumerator end()
    {
        yield return new WaitForSeconds(1f);
        collider1_1.SetActive(false);
        collider2_2.SetActive(false);
        collider1_2.SetActive(false);
        collider2_1.SetActive(false);
    }
}
