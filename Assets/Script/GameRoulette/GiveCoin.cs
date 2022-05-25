using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class GiveCoin : NetworkBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.GetComponent<NetworkObject>().IsLocalPlayer)
        {
            collision.gameObject.GetComponent<PlayerKarmaPoint>().GainKarmaPointServerRpc(100);
            collision.GetComponent<TeleportPlayer>().TeleportOnServerRpc(-54.9f, 20.21f, "waitRoulette", "Roulette");
        }
    }
}
