using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YeetPlayer : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.position = new Vector2(-30.49f,8.52f);
        }
    }
}
