using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class RouletteGame : NetworkBehaviour
{
    public GameObject collider1_1;
    public GameObject collider1_2;
    public GameObject collider2_1;
    public GameObject collider2_2;
    public GameObject CountDownText;
    Text Countdowntxt;
    public bool IsPlaying = false;
    public GameObject Teleport_Play;

    public int randomnum;

    private void Start()
    {
        
    }
    public void StartGame()
    {
        closeWarpServerRpc();
        IsPlaying = true;
        CountDownText.SetActive(true);
        Countdowntxt = CountDownText.GetComponent<Text>();
        //count down from 10
        StartCoroutine(Countdown());
        //random 
        //checkresult
        
    }
    public int randomRouette()
    {
        randomnum = Random.Range(1, 3);
        Debug.Log("Roulette : " + randomnum);
        return randomnum;
    }
    void checkresut(int result)
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
        CountDownText.SetActive(false);
        IsPlaying = false;
        OpenWarpServerRpc();
    }
 
    private IEnumerator Countdown()
    {
        float count = 0f;
        float totalTime = 5f;
        while (totalTime >= count)
        {
            totalTime -= Time.deltaTime;
            Countdowntxt.text = totalTime.ToString();
            yield return null;
        }
        checkresut(randomRouette());
        
    }
   [ServerRpc(RequireOwnership = false)]
   void closeWarpServerRpc()
    {
        closeWarpClientRpc();
    }
    [ClientRpc]
    void closeWarpClientRpc()
    {
        Teleport_Play.SetActive(false);
    }

    [ServerRpc(RequireOwnership = false)]
    void OpenWarpServerRpc()
    {
        OpenWarpClientRpc();
    }
    [ClientRpc]
    void OpenWarpClientRpc()
    {
        Teleport_Play.SetActive(true);
    }


}
