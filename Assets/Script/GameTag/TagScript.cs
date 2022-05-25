using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class TagScript : NetworkBehaviour
{
    TeleportPlayer check;
    int score = 0;
    public Text scoreText;
    public LoginCredential vivoxlogin;
    private void Start()
    {
        //score = 0;
        //scoreText.text = "Karma Point";
        GetComponent<CircleCollider2D>().enabled = false;
        vivoxlogin = GameObject.Find("VivoxLoginCredential").GetComponent<LoginCredential>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !IsLocalPlayer)
        {

            collision.GetComponent<TeleportPlayer>().TeleportOnServerRpc(46.5f, -25.8f, "waitTag", "Tag");
        
            Debug.Log("LocalPlayer =" + IsLocalPlayer);
            
            collision.GetComponent<TeleportPlayer>().Currentposition = "waitTag";

            collision.GetComponent<PlayerKarmaPoint>().LoseKarmaPointServerRpc(50);

            if (this.gameObject.GetComponentInParent<TeleportPlayer>().Currentposition == "Tag" && IsLocalPlayer)

            {
                Debug.Log("isLocalPlayer =" + IsLocalPlayer + " Gain");
                this.gameObject.GetComponentInParent<PlayerKarmaPoint>().GainKarmaPointServerRpc(100);
            }
           
                
            

        }

    }

    //private void Update()
    //{
    //    scoreText.text = score.ToString();
    //}
}
