using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class TeleportPlayer : NetworkBehaviour
{
    public string Currentposition = "Mainroom";
    public GameObject rouletteRoomPanel;
    public GameObject tagRoomPanel;
    public GameObject BoardRoomPanel;
    public GameObject MainRoomPanel;
    public Collider2D tagColider;
    public LoginCredential vivoxlogin;

    private void Start()
    {
        vivoxlogin = GameObject.Find("VivoxLoginCredential").GetComponent<LoginCredential>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Teleport")
        {
            float teleport_Pos_X = collision.GetComponent<TeleportPosition>().posX;
            float teleport_Pos_Y = collision.GetComponent<TeleportPosition>().posY;
            string pos = collision.GetComponent<TeleportPosition>().Roomname;
            string vivoxname = collision.GetComponent<TeleportPosition>().VivoxChannel;
            Teleport(teleport_Pos_X, teleport_Pos_Y,pos,vivoxname);
            
        }
    }
    public void Teleport(float posX, float posY, string roomname, string Vivoxchannelname)
    {
        transform.position = new Vector2(posX, posY);
        Currentposition = roomname;    
        ShowRoomUI();
        if(roomname != "Tag")
        {
            vivoxlogin.getPlayerCurrentPosition(Vivoxchannelname);
        }

        //if (NetworkManager.Singleton.IsServer)
        //{
        //    transform.position = new Vector2(posX, posY);
        //    Currentposition = roomname;
        //}
        //else
        //{
        //    SubmitTeleportRequestServerRpc();
        //}
        
    }

    [ClientRpc] //ทำงานพร้อมกัน
    void TriggerColiderOnClientRpc()
    {        
         tagColider.enabled = true;
    }

    [ServerRpc(RequireOwnership = false)]
    void TriggerColiderOnServerRpc()
    {
        TriggerColiderOnClientRpc();
    }

    [ClientRpc]
    void TriggerColiderOffClientRpc()
    {
        tagColider.enabled = false;
    }

    [ServerRpc(RequireOwnership = false)]
    void TriggerColiderOffServerRpc()
    {

        TriggerColiderOffClientRpc();
    }


    private void Update()
    {

        if (Currentposition == "Tag" && IsLocalPlayer)
        {
            //GetComponent<CapsuleCollider2D>().enabled = false;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TriggerColiderOnServerRpc();
                //GetComponent<CircleCollider2D>().enabled = true;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                TriggerColiderOffServerRpc();
                //GetComponent<CircleCollider2D>().enabled = false;
            }
        }
    }
    void ShowRoomUI()
    {
        if(Currentposition == "Mainroom")
        {
            MainRoomPanel.SetActive(true);
            rouletteRoomPanel.SetActive(false);
            BoardRoomPanel.SetActive(false);
            tagRoomPanel.SetActive(false);
        }
        else if (Currentposition == "Roulette")
        {
            MainRoomPanel.SetActive(false);
            rouletteRoomPanel.SetActive(true);
            BoardRoomPanel.SetActive(false);
            tagRoomPanel.SetActive(false);
        }
        else if (Currentposition == "Tag")
        {
            MainRoomPanel.SetActive(false);
            rouletteRoomPanel.SetActive(false);
            BoardRoomPanel.SetActive(false);
            tagRoomPanel.SetActive(true);
           

        }
        else if (Currentposition == "Board")
        {
            MainRoomPanel.SetActive(false);
            rouletteRoomPanel.SetActive(false);
            BoardRoomPanel.SetActive(true);
            tagRoomPanel.SetActive(false);
        }
    }
    
    
}
