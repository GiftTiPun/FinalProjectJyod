using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;


public class YeetPlayer : NetworkBehaviour
{
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.GetComponent<NetworkObject>().IsLocalPlayer )
        {
            collision.GetComponent<TeleportPlayer>().TeleportOnServerRpc(-54.9f, 20.21f, "waitRoulette", "Roulette");
        }
    }
}

