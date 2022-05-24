using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class SkinUi : NetworkBehaviour
{
    public GameObject shopskin;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            if(!IsLocalPlayer)
            {
                shopskin.SetActive(true);
            }
            else
            {

            }
            
        }
    }
   public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!IsLocalPlayer)
            {
                shopskin.SetActive(false);
            }
            else
            {

            }
        }
    }
}
