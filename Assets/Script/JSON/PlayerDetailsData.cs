using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerDetailsData 
{
    private string fileName = "PlayerDatail.Json";
    private string filePath = "";
    private PlayerDetailList playerDetailList;

    private static PlayerDetailsData Instance;

    public PlayerDetailsData()
    {
        playerDetailList = new PlayerDetailList();
        filePath = Application.persistentDataPath + "" + fileName;
    }

    public static PlayerDetailsData GetInstance()
    {
        if(Instance == null)
        {
            Instance = new PlayerDetailsData();
        }
        return Instance;
    }
    //public PlayerDetailList GetPlayerDetailsList()
    //{
    //    if(File.Exists(filePath))
    //    {
    //        string jsonData = File.ReadAllText(filePath);
    //        Debug.Log("Load Json Data " + jsonData);
    //        playerDetailList = JsonUtility.FromJson<PlayerDetailList>(jsonData);
    //    }

    //    return playerDetailList;
    //}

    public void AddPlayerDetails(PlayerInfo playerInfo)
    {
        playerDetailList.playerDetailList.Add(playerInfo);

        string PlayerDatailsJson = JsonUtility.ToJson(playerDetailList);

        Debug.Log("Save Json Data" + PlayerDatailsJson);

        File.WriteAllText(filePath, PlayerDatailsJson);
    }
}
