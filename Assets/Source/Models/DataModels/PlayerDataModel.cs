using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataModel : DataModel
{
    public static PlayerDataModel Data;
    public int Level = 1;
    public int LevelIndex = 0;
    public int Score = 0;

    public PlayerDataModel Load()
    {
        if (Data == null)
        {
            Data = this;
            object data = LoadData();

            if (data != null)
            {
                Data = (PlayerDataModel)data;
            }
        }
        return Data;
    }

    public void Save()
    {
        Save(Data);
    }
}
