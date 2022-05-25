using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class PlayerKarmaPoint : NetworkBehaviour
{
    public int karmaPoint;
    [SerializeField] Text karmaPointText;
    [SerializeField] Animator p_animator;
    
    
    

    public void Start()
    {
        karmaPoint = 1000;
        karmaPointText = GameObject.Find("karmapointText").GetComponent<Text>();
        p_animator = gameObject.GetComponent<Animator>();
       
       
    }

    [ClientRpc]
    public void GainKarmaPointClientRpc(int amount)
    {
        karmaPoint += amount;
    }
    [ServerRpc(RequireOwnership = false)]
    public void GainKarmaPointServerRpc(int amount)
    {
        GainKarmaPointClientRpc(amount);
    }
    [ClientRpc]
    public void LoseKarmaPointClientRpc(int amount)
    {
        karmaPoint -= amount;
    }
    [ServerRpc(RequireOwnership = false)]
    public void LoseKarmaPointServerRpc(int amount)
    {
        LoseKarmaPointClientRpc(amount);
    }

    [ClientRpc]
    public void CheckPointClientRpc()
    {
        karmaPointText.text = karmaPoint.ToString();
    }
    [ServerRpc(RequireOwnership = false)]
    public void CheckPointServerRpc()
    {
        CheckPointClientRpc();
    }
    public void Update()
    {
        if(gameObject.GetComponent<NetworkObject>().IsLocalPlayer)
        {
            CheckPointServerRpc();
        }
       
    }

    public void Changeskin2()
    {
        //this.LoseKarmaPoint(250);
        if(!IsLocalPlayer)
        {
            p_animator.SetBool("Skin1", false);
            p_animator.SetBool("Skin2", true);
            p_animator.SetBool("Skin3", false);
            p_animator.SetBool("Skin4", false);
            Debug.Log("wtf");
        }
       


    }
   

}

