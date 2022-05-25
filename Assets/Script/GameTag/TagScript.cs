using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class TagScript : NetworkBehaviour
{
    TeleportPlayer check;
    int score=0;
    public Text scoreText;
    public LoginCredential vivoxlogin;
    public LayerMask playerLayer;
    private void Start()
    {
        score = 0;
        scoreText.text = "Karma Point";
        GetComponent<CircleCollider2D>().enabled = false;
        vivoxlogin = GameObject.Find("VivoxLoginCredential").GetComponent<LoginCredential>();
    }

    public void Tag()
    {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        Collider2D[] Hit = Physics2D.OverlapCircleAll(transform.position, 1f,playerLayer);
        foreach(Collider2D n in Hit )
        {
            if(n.gameObject == GetComponentInParent<MainPlayer>().gameObject)
=======
        if (collision.gameObject.tag =="Player" && !IsLocalPlayer )
        {
            
            collision.GetComponent<TeleportPlayer>().TeleportOnServerRpc(46.5f, -25.8f, "waitTag", "Tag");
            //collision.transform.position = new Vector2(46.5f, -25.8f);
            //score = score+5;
            Debug.Log("LocalPlayer =" + IsLocalPlayer);
            Debug.Log(score);
            collision.GetComponent<TeleportPlayer>().Currentposition = "waitTag";
            if (this.gameObject.GetComponentInParent<TeleportPlayer>().Currentposition == "waitTag")

            {
                collision.GetComponent<PlayerKarmaPoint>().LoseKarmaPoint(50);
            }
            if (this.gameObject.GetComponentInParent<TeleportPlayer>().Currentposition == "Tag")
           
>>>>>>> parent of 61fd023 (FixTag4)
            {
                return;
            }
<<<<<<< HEAD
            n.GetComponent<TeleportPlayer>().TeleportOnServerRpc(46.5f, -25.8f, "waitTag", "Tag");
            n.GetComponent<TeleportPlayer>().Currentposition = "waitTag";
            n.GetComponent<PlayerKarmaPoint>().LoseKarmaPointServerRpc(50);
            GetComponentInParent<PlayerKarmaPoint>().GainKarmaPointServerRpc(100);
=======
        if (collision.gameObject.tag == "Player" && !IsLocalPlayer)
=======
        if (collision.gameObject.tag =="Player" && !IsLocalPlayer )
>>>>>>> parent of 61fd023 (FixTag4)
        {
            
            collision.GetComponent<TeleportPlayer>().TeleportOnServerRpc(46.5f, -25.8f, "waitTag", "Tag");
        
            Debug.Log("LocalPlayer =" + IsLocalPlayer);
<<<<<<< HEAD
            
=======
            Debug.Log(score);
>>>>>>> parent of 61fd023 (FixTag4)
            collision.GetComponent<TeleportPlayer>().Currentposition = "waitTag";
            if (this.gameObject.GetComponentInParent<TeleportPlayer>().Currentposition == "waitTag")

<<<<<<< HEAD
            collision.GetComponent<PlayerKarmaPoint>().LoseKarmaPointServerRpc(50);

            if (this.gameObject.GetComponentInParent<TeleportPlayer>().Currentposition == "Tag" && IsLocalPlayer)

=======
            {
                collision.GetComponent<PlayerKarmaPoint>().LoseKarmaPoint(50);
            }
            if (this.gameObject.GetComponentInParent<TeleportPlayer>().Currentposition == "Tag")
           
>>>>>>> parent of 61fd023 (FixTag4)
            {
                Debug.Log("isLocalPlayer =" + IsLocalPlayer + " Gain");
                this.gameObject.GetComponentInParent<PlayerKarmaPoint>().GainKarmaPointServerRpc(100);
            }
<<<<<<< HEAD
           
                
            

>>>>>>> parent of 4282162 (FixTag12+Pun)
        }
=======
          
        }
       
>>>>>>> parent of 61fd023 (FixTag4)
=======
          
        }
       
>>>>>>> parent of 61fd023 (FixTag4)
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
