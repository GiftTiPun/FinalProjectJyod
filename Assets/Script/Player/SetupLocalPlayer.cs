using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour
{
    [SerializeField]
    public NetworkVariable<NetworkString> playerName = new NetworkVariable<NetworkString>();
    public Text namePrefab;
    public Text nameLabel;
    public Transform namePos;
    private LoginManager loginManager;
    public JsonWriter PlayernameJson;


   
    void Start()
    {
        if(IsLocalPlayer)
        {
            CameraFollow360.player = this.gameObject.transform;
        }
        else
        {

        }
        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        nameLabel = Instantiate(namePrefab, Vector3.zero, Quaternion.identity) as Text;
        nameLabel.transform.SetParent(canvas.transform);
        if(IsServer)
        {
            
        }
        if(IsLocalPlayer)
        {
            loginManager = GameObject.FindObjectOfType<LoginManager>();
            if(loginManager != null)
            {
                UpdateClientNameServerRpc(loginManager.playerNameInputField.text);
            }
        }

    }
  
    [ServerRpc(RequireOwnership = false)]
    public void UpdateClientNameServerRpc(string name)
    {
        //UpdateClientNameClientRpc();
        playerName.Value = name;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nameLablePos = Camera.main.WorldToScreenPoint(namePos.position);
        nameLabel.transform.position = nameLablePos;
        if(!string.IsNullOrEmpty(playerName.Value))
        {
            nameLabel.text = playerName.Value;
        }
    }

    private void OnDestroy()
    {
        if (nameLabel != null)
        {
            Destroy(nameLabel.gameObject);
        }
    }

   


}
