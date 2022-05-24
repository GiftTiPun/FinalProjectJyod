using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

[SerializeField]
public class PlayerInfo
{
    public string namePlayer;
    public Sprite currentskin;
    public int karmaPoint;
}
[SerializeField]
public class PlayerDetailList
{
    public List<PlayerInfo> playerDetailList;
    public PlayerDetailList()
    {
        playerDetailList = new List<PlayerInfo>();
    }
}
public class JsonWriter : MonoBehaviour
{
    public InputField NameInputField;

    public void NameToJson()
    {
        PlayerInfo playerinfo = new PlayerInfo();
        playerinfo.namePlayer = NameInputField.text;
        PlayerDetailsData.GetInstance().AddPlayerDetails(playerinfo);

    }

   
}
