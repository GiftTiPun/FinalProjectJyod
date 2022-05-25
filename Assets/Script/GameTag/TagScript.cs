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
    public LayerMask playerLayer;
    private void Start()
    {
        //score = 0;
        //scoreText.text = "Karma Point";
        GetComponent<CircleCollider2D>().enabled = false;
        vivoxlogin = GameObject.Find("VivoxLoginCredential").GetComponent<LoginCredential>();
    }

    public void Tag()
    {
<<<<<<< HEAD
        Collider2D[] Hit = Physics2D.OverlapCircleAll(transform.position, 1f,playerLayer);
        foreach(Collider2D n in Hit )
        {
            if(n.gameObject == GetComponentInParent<MainPlayer>().gameObject)
            {
                return;
            }
            n.GetComponent<TeleportPlayer>().TeleportOnServerRpc(46.5f, -25.8f, "waitTag", "Tag");
            n.GetComponent<TeleportPlayer>().Currentposition = "waitTag";
            n.GetComponent<PlayerKarmaPoint>().LoseKarmaPointServerRpc(50);
            GetComponentInParent<PlayerKarmaPoint>().GainKarmaPointServerRpc(100);
=======
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
           
                
            

>>>>>>> parent of 4282162 (FixTag12+Pun)
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player" && !IsLocalPlayer)
    //    {

    //        collision.GetComponent<TeleportPlayer>().TeleportOnServerRpc(46.5f, -25.8f, "waitTag", "Tag");
        
    //        Debug.Log("LocalPlayer =" + IsLocalPlayer);
            
    //        collision.GetComponent<TeleportPlayer>().Currentposition = "waitTag";

    //        if(collision != GetComponentInParent<Collider2D>())
    //        {
    //            collision.GetComponent<PlayerKarmaPoint>().LoseKarmaPointServerRpc(50);
    //            this.gameObject.GetComponentInParent<PlayerKarmaPoint>().GainKarmaPointServerRpc(100);
    //        }
            
    //    }

    //}

    //private void Update()
    //{
    //    scoreText.text = score.ToString();
    //}
}
