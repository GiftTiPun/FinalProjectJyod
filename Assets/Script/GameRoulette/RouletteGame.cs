using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletteGame : MonoBehaviour
{
    public GameObject collider1_1;
    public GameObject collider1_2;
    public GameObject collider2_1;
    public GameObject collider2_2;
    public bool IsStartGame = false;
    public Text CountDownText;

    public float randomnum;
    
    public void StartGame()
    {
        //count down from 10
        StartCoroutine(Countdown());
        //random 
        //checkresult
        checkresut(randomRouette());
    }
    public float randomRouette()
    {
        randomnum = Random.Range(1f, 2f);
        Debug.Log("Roulette : " + randomnum);
        return randomnum;
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

    private IEnumerator Countdown()
    {
        float count = 0f;
        float totalTime = 10f;
        while (totalTime >= count)
        {
            count += Time.deltaTime;
            CountDownText.text = count.ToString();
            yield return null;
        }
    }
}
