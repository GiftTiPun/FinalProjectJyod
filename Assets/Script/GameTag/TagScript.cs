using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class TagScript : NetworkBehaviour
{
    TeleportPlayer check;
    private void Start()
    {
        
        GetComponent<CircleCollider2D>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Player" && !IsLocalPlayer && collision.gameObject != this.gameObject)
        {
            collision.transform.position = new Vector2(0f, 0f);
            Debug.Log("LocalPlayer =" + IsLocalPlayer);
        }
    }
}
