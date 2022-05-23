using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public GameObject playButtonUI;
    public string[] PlayerIDWantToPlay;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playButtonUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playButtonUI.SetActive(false);
    }

    public void RegistoPlay()
    {
        //get payer id and store in array or list
    }
}
