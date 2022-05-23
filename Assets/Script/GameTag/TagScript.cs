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
    private void Start()
    {
        score = 0;
        scoreText.text = "Karma Point";
        GetComponent<CircleCollider2D>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Player" && !IsLocalPlayer )
        {
            collision.transform.position = new Vector2(0f, 0f);
            //score = score+5;
            Debug.Log("LocalPlayer =" + IsLocalPlayer);
            Debug.Log(score);
            
        }
    }

    //private void Update()
    //{
    //    scoreText.text = score.ToString();
    //}
}
