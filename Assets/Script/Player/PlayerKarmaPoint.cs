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

    public void GainKarmaPoint(int amount)
    {
        karmaPoint += amount;
    }
    public void LoseKarmaPoint(int amount)
    {
        karmaPoint -= amount;
    }

    [ClientRpc]
    public void CheckPointClientRpc()
    {
        karmaPointText.text = karmaPoint.ToString();
    }
    [ServerRpc]
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
       


        //this.GetComponent<Animator>().SetBool("Skin2", true);
        //this.GetComponent<Animator>().SetBool("Skin3", false);
        //this.GetComponent<Animator>().SetBool("Skin4", false);

        //GetComponent<Animator>().runtimeAnimatorController = skin2 as RuntimeAnimatorController;
        //Debug.Log("YOOO");
    }
    public void Changeskin3()
    {
        //this.LoseKarmaPoint(250);
        //this.GetComponent<Animator>().SetBool("Skin3", true);
        //this.GetComponent<Animator>().SetBool("Skin2", false);
        //this.GetComponent<Animator>().SetBool("Skin4", false);

        //GetComponent<Animator>().runtimeAnimatorController = skin2 as RuntimeAnimatorController;
        //Debug.Log("YOOO");
    }
    public void Changeskin4()
    {
        //this.LoseKarmaPoint(250);
        //this.GetComponent<Animator>().SetBool("Skin4", true);
        //this.GetComponent<Animator>().SetBool("Skin3", false);
        //this.GetComponent<Animator>().SetBool("Skin2", false);

        //GetComponent<Animator>().runtimeAnimatorController = skin2 as RuntimeAnimatorController;
        //Debug.Log("YOOO");
    }

}

