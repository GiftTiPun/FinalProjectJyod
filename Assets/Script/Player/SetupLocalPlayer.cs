using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class SetupLocalPlayer : NetworkBehaviour
{
    public Text namePrefab;
    public Text nameLabel;
    public Transform namePos;
    void Start()
    {
        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        nameLabel = Instantiate(namePrefab, Vector3.one, Quaternion.identity) as Text;
        nameLabel.transform.SetParent(canvas.transform);

    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 nameLablePos = Camera.main.ScreenToWorldPoint(namePos.position);
        //nameLabel.transform.position = nameLablePos;
    }
}
