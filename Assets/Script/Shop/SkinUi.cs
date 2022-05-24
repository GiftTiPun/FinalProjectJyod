using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class SkinUi : NetworkBehaviour
{
    public GameObject shopskin;
    public PlayerKarmaPoint point;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player" && collision.GetComponent<NetworkObject>().IsLocalPlayer)
        {
          
            shopskin.SetActive(true);
            
        }
        else
        {
            Debug.Log("POG");
        }
    }
   public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.GetComponent<NetworkObject>().IsLocalPlayer)
        {
            
            shopskin.SetActive(false);
            
        }
        else
        {
            Debug.Log("LUCA");
        }
    }

   
}
