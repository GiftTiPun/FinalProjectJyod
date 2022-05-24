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
    private void Start()
    {
        score = 0;
        scoreText.text = "Karma Point";
        GetComponent<CircleCollider2D>().enabled = false;
        vivoxlogin = GameObject.Find("VivoxLoginCredential").GetComponent<LoginCredential>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Player" && !IsLocalPlayer )
        {
            vivoxlogin.getPlayerCurrentPosition("waitTag");
            collision.GetComponent<TeleportPlayer>().Teleport(46.5f, -25.8f, "waitTag");
            //collision.transform.position = new Vector2(46.5f, -25.8f);
            //score = score+5;
            Debug.Log("LocalPlayer =" + IsLocalPlayer);
            Debug.Log(score);
            collision.GetComponent<TeleportPlayer>().Currentposition = "waitTag";
            

        }
    }

    //private void Update()
    //{
    //    scoreText.text = score.ToString();
    //}
}
