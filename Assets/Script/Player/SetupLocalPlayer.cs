using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class SetupLocalPlayer : MonoBehaviour
{
    public Text namePrefab;
    public Text nameLabel;
    public Transform namePos;
    void Start()
    {
        GameObject canvas = GameObject.FindWithTag("MainCanvas");
        nameLabel = Instantiate(namePrefab, Vector2.zero, Quaternion.identity) as Text;
        nameLabel.transform.SetParent(canvas.transform);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 nameLablePos = Camera.main.WorldToScreenPoint(namePos.position);
        nameLabel.transform.position = nameLablePos;
    }
}
