using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveCoin : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerKarmaPoint>().GainKarmaPoint(100f);
            collision.GetComponent<TeleportPlayer>().TeleportOnServerRpc(-54.9f, 20.21f, "waitRoulette", "Roulette");
        }
    }
}
