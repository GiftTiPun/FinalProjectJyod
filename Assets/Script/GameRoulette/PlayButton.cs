using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class PlayButton : NetworkBehaviour
{
    public GameObject playButtonUI;
    public GameObject RouetteManager;
    public GameObject Teleport_Play;
    bool isplaying = false;

    private void Update()
    {
        isplaying = RouetteManager.GetComponent<RouletteGame>().IsPlaying;
        if (isplaying)
        {
            playButtonUI.SetActive(false);
            Teleport_Play.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && collision.GetComponent<NetworkObject>().IsLocalPlayer)
        {
            playButtonUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playButtonUI.SetActive(false);
    }

    
}
